using B.Service.Infrastructure.Requests;
using B.Service.Infrastructure.Resources;
using B.Service.Infrastructure.Responses;
using B.Service.Models;
using B.Service.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

namespace B.Service.Services.Implementations;
public class SettingsService : ISettingsService
{
    private readonly IConfiguration _configuration;

    public SettingsService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<GetResponse<Settings>> GetSettingsAsync()
    {
        var settingsPath = new SettingsPath(_configuration);

        if (File.Exists(settingsPath.CurrentPath))
        {
            var text = await File.ReadAllTextAsync(settingsPath.CurrentPath);

            var data = JsonSerializer.Deserialize<Settings>(text)!;

            var settings = new Settings(data.CheckInterval, data.FilePath);

            return new GetResponse<Settings>(settings);
        }
        else
        {
            var settings = new Settings(5, "C:\\Test");

            await WriteSettingsToTextAsync(settings, settingsPath.CurrentPath);

            return new GetResponse<Settings>(settings);
        }
    }

    public async Task<PostResponse> SaveSettingsAsync(SaveSettingsReq input)
    {
        var settingsPath = new SettingsPath(_configuration);

        if (File.Exists(settingsPath.CurrentPath))
            File.Delete(settingsPath.CurrentPath);

        var settings = new Settings(input.CheckInterval, input.FilePath);        

        await WriteSettingsToTextAsync(settings, settingsPath.CurrentPath);

        return new PostResponse();
    }

    private async Task WriteSettingsToTextAsync(Settings settings, string filePath)
    {
        var jsonData = JsonSerializer.Serialize(settings);

        using var sw = new StreamWriter(filePath, true);

        await sw.WriteLineAsync(jsonData);
    }
}

using B.Service.Infrastructure.Requests;
using B.Service.Infrastructure.Responses;
using B.Service.Models;
using B.Service.Services.Abstractions;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

namespace B.Service.Services.Implementations;
public class DataService : IDataService
{
    private readonly ISettingsService _settingsService;

    public DataService(ISettingsService settingsService)
    {
        _settingsService = settingsService;
    }

    public async Task<GetAllResponse<Data>> CheckDataAsync()
    {
        var settings = await _settingsService.GetSettingsAsync();

        var dataPath = Path.Combine(settings.Data.FilePath, "data.txt");

        var archivePath = Path.Combine(settings.Data.FilePath, "archive.txt");

        if (File.Exists(archivePath))
        {
            var text = await File.ReadAllTextAsync(dataPath);
            var archive = await File.ReadAllTextAsync(archivePath);

            var data = JsonSerializer.Deserialize<List<Data>>(text)!;
            var archiveData = JsonSerializer.Deserialize<List<Data>>(text)!;

            if (data.Any(m => !archiveData.Any(x => x.Date != m.Date ||
                                              x.Open != m.Open ||
                                              x.Volume != m.Volume ||
                                              x.Close != m.Close ||
                                              x.Low != m.Low)))
            {
                File.Delete(archivePath);
                File.Delete(dataPath);

                var jsonData = JsonSerializer.Serialize(data);
                var jsonArchive = JsonSerializer.Serialize(archiveData);

                using var dataSw = new StreamWriter(dataPath, true);
                using var arcSw = new StreamWriter(archivePath, true);

                await dataSw.WriteLineAsync(jsonData);
                await arcSw.WriteLineAsync(jsonArchive);

                return new GetAllResponse<Data>(data);
            }

            return new GetAllResponse<Data>(data);
        }
        else
        {
            return new GetAllResponse<Data>("Nothing new");
        }
    }
}

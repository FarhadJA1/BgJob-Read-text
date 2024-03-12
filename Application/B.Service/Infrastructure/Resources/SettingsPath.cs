using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace B.Service.Infrastructure.Resources;
public class SettingsPath
{
    public readonly string CurrentPath;
    private readonly IConfiguration _configuration;

    public SettingsPath(IConfiguration configuration)
    {
        _configuration = configuration;

        var assemblyFolder = Assembly.GetExecutingAssembly().Location;

        var path = Path.Combine(Path.GetDirectoryName(assemblyFolder)!, _configuration!["SettingsLocation"]);

        CurrentPath = path;
    }
}

using System.ComponentModel.DataAnnotations;

namespace B.Service.Infrastructure.Requests;
public class SaveSettingsReq
{
    [Required]
    public int CheckInterval { get; set; }

    [Required]
    public string FilePath { get; set; }
}

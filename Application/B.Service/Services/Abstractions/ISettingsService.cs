using B.Service.Infrastructure.Requests;
using B.Service.Infrastructure.Responses;
using B.Service.Models;

namespace B.Service.Services.Abstractions;
public interface ISettingsService
{
    Task<PostResponse> SaveSettingsAsync(SaveSettingsReq input);
    Task<GetResponse<Settings>> GetSettingsAsync();    
}

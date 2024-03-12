using B.Service.Infrastructure.Requests;
using B.Service.Infrastructure.Responses;
using B.Service.Models;

namespace B.Service.Services.Abstractions;
public interface IDataService
{
    Task<GetAllResponse<Data>> CheckDataAsync();
}

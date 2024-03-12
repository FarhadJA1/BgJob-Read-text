namespace B.Service.Infrastructure.Responses;
public class GetAllResponse<T>
{
    public bool IsSucceded { get; set; }
    public string Message { get; set; }
    public List<T> Data { get; set; }

    public GetAllResponse(string message)
    {
        IsSucceded = false;
        Message = message;
        Data = new List<T>(0);
    }

    public GetAllResponse(List<T> data)
    {
        IsSucceded = true;
        Message = string.Empty;
        Data = data;
    }
}

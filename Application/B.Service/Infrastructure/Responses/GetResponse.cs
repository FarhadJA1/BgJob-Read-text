namespace B.Service.Infrastructure.Responses;
public class GetResponse<T> where T : class
{
    public bool IsSucceeded { get; set; }
    public string Message { get; set; }
    public T Data { get; set; }

    public GetResponse(string message)
    {
        IsSucceeded = false;
        Message = message;
        Data = null!;
    }

    public GetResponse(T data)
    {
        IsSucceeded = true;
        Message = string.Empty;
        Data = data;
    }
}

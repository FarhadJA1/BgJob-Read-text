namespace B.Service.Infrastructure.Responses;
public class PostResponse
{
    public bool IsSucceded { get; set; }
    public string Message { get; set; }

    public PostResponse(string errorMessage)
    {
        IsSucceded = false;
        Message = errorMessage;
    }

    public PostResponse()
    {
        IsSucceded = true;
        Message = string.Empty;
    }
}

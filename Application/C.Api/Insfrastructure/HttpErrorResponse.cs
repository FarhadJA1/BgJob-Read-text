namespace A.Api.Insfrastructure;
public class HttpErrorResponse
{
    public HttpErrorResponse(List<string> messages)
    {
        Messages = messages;
        Succeeded = false;
    }
    public bool Succeeded { get; set; }
    public List<string> Messages { get; private set; }
}

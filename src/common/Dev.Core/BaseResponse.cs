namespace Dev.Core;

public abstract class BaseResponse
{
    protected BaseResponse()
    {
        Success = true;
    }
    protected BaseResponse(string message)
    {
        Success = true;
        Message = message;
    }

    protected BaseResponse(string message, bool success)
    {
        Success = success;
        Message = message;
    }

    public bool Success { get; set; }
    public string Message { get; set; } = string.Empty;
    public List<string> ValidationErrors { get; set; } = new();
}

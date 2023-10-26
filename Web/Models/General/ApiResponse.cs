namespace Web.Models.General;

public class ApiResponse
{
    public bool IsSuccess { get; set; } = true;
    public string Message { get; set; } = string.Empty;
    public object? Result { get; set; }
}
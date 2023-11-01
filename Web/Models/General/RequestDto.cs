using Web.Utils;

namespace Web.Models.General;

public class RequestDto
{
    public ApiType ApiType { get; set; } = ApiType.GET;
    public string Url { get; set; }
    public object Data { get; set; }
    public string AccessToken { get; set; }
    public string HttpClientName { get; set; }
}
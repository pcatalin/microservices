using System.Net;
using System.Text;
using Newtonsoft.Json;
using Web.Models.General;
using Web.Service.Interface;
using Web.Utils;

namespace Web.Service;

public class RequestService : IRequestService
{
    private readonly IHttpClientFactory _httpClientFactory;
    
    public RequestService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }
    
    public async Task<ApiResponse?> SendAsync(RequestDto requestDto)
    {
        try
        {
            var client = _httpClientFactory.CreateClient();
            HttpRequestMessage message = new();
            message.Headers.Add("Accept", "application/json");
            // token

            message.RequestUri = new Uri(requestDto.Url);

            switch (requestDto.ApiType)
            {
                case ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;

                case ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;

                case ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;

                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            if (requestDto.ApiType is ApiType.POST or ApiType.PUT)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
            }

            var response = await client.SendAsync(message);
            ApiResponse? apiResponse = null;
            
            switch (response.StatusCode)
            {
                case HttpStatusCode.NotFound:
                    return new ApiResponse { IsSuccess = false, Message = "Not Found" };
                
                case HttpStatusCode.Forbidden:
                    return new ApiResponse { IsSuccess = false,  Message = "Access Denied" };
                
                case HttpStatusCode.Unauthorized:
                    return new ApiResponse { IsSuccess = false,  Message = "Unauthorized" };
                
                case HttpStatusCode.InternalServerError:
                    return new ApiResponse { IsSuccess = false,  Message = "Internal Server Error" };
                
                case HttpStatusCode.OK:
                case HttpStatusCode.Created:
                case HttpStatusCode.Accepted:
                    var content = await response.Content.ReadAsStringAsync();
                    apiResponse = JsonConvert.DeserializeObject<ApiResponse>(content);
                    break;
                
                default:
                    throw new NotImplementedException($"Unexpected status code caught: {response.StatusCode}");
            }
            
            return apiResponse;
        }
        catch (Exception ex)
        {
            return new ApiResponse
            {
                Message = ex.Message,
                IsSuccess = false
            };
        }
    }
}
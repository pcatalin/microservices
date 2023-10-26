using Web.Models;
using Web.Models.General;

namespace Web.Service.Interface;

public interface IRequestService
{
    Task<ApiResponse?> SendAsync(ApiRequest request);
}
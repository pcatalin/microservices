using Web.Models.Dto;
using Web.Models.General;
using Web.Service.Interface;
using Web.Utils;

namespace Web.Service;

public class CouponService : ICouponService
{
    private readonly IRequestService _requestService;
    private readonly IApiUtils _apiUtils;

    public CouponService(IRequestService requestService, IApiUtils apiUtils)
    {
        _requestService = requestService;
        _apiUtils = apiUtils;
    }

    public async Task<ApiResponse?> GetAsync(int id)
    {
        return await _requestService.SendAsync(new RequestDto
        {
            Url = $"{_apiUtils.CouponApiInfo.BaseUrl}/api/coupon/{id}"
        });
    }
    
    public async Task<ApiResponse?> GetAsync(string code)
    {
        return await _requestService.SendAsync(new RequestDto
        {
            Url = $"{_apiUtils.CouponApiInfo.BaseUrl}/api/coupon/GetByCode/{code}"
        });
    }

    public async Task<ApiResponse?> GetAllAsync()
    {
        return await _requestService.SendAsync(new RequestDto
        {
            Url = $"{_apiUtils.CouponApiInfo.BaseUrl}/api/coupon/getAll"
        });
    }

    public async Task<ApiResponse?> CreateAsync(CouponDto dto)
    {
        return await _requestService.SendAsync(new RequestDto
        {
            ApiType = ApiType.POST,
            Url = $"{_apiUtils.CouponApiInfo.BaseUrl}/api/coupon/",
            Data = dto
        });
    }

    public async Task<ApiResponse?> UpdateASync(CouponDto dto)
    {
        return await _requestService.SendAsync(new RequestDto
        {
            ApiType = ApiType.PUT,
            Url = $"{_apiUtils.CouponApiInfo.BaseUrl}/api/coupon/",
            Data = dto
        });
    }

    public async Task<ApiResponse?> DeleteAsync(int id)
    {
        return await _requestService.SendAsync(new RequestDto
        {
            ApiType = ApiType.DELETE,
            Url = $"{_apiUtils.CouponApiInfo.BaseUrl}/api/coupon/{id}"
        });
    }
}
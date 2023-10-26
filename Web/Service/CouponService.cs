using Web.Models.Dto;
using Web.Models.General;
using Web.Service.Interface;
using Web.Utils;

namespace Web.Service;

public class CouponService : ICouponService
{
    private readonly IRequestService _requestService;

    public CouponService(IRequestService requestService)
    {
        _requestService = requestService;
    }

    public async Task<ApiResponse> GetAsync(int id)
    {
        throw new NotImplementedException();
    }
    
    public async Task<ApiResponse> GetAsync(string code)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse> CreateAsync(CouponDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse> UpdateASync(CouponDto dto)
    {
        throw new NotImplementedException();
    }

    public async Task<ApiResponse> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}
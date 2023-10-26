using Web.Models.Dto;
using Web.Models.General;

namespace Web.Service.Interface;

public interface ICouponService
{
    Task<ApiResponse> GetAsync(int id);
    Task<ApiResponse> GetAsync(string code);
    Task<ApiResponse> GetAllAsync();
    Task<ApiResponse> CreateAsync(CouponDto dto);
    Task<ApiResponse> UpdateASync(CouponDto dto);
    Task<ApiResponse> DeleteAsync(int id);
}


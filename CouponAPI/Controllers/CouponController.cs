using AutoMapper;
using CouponAPI.Data;
using CouponAPI.Models;
using CouponAPI.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CouponAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CouponController : ControllerBase
{
    private readonly AppDbContext _dbContext;
    private readonly IMapper _mapper;

    private readonly ApiResponse _apiResponse;

    public CouponController(AppDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
        
        _apiResponse = new ApiResponse();
    }

    [HttpGet("getAll")]
    public async Task<ApiResponse> GetAllAsync()
    {
        try
        {
            var coupons = await _dbContext.Coupons.ToListAsync();
            _apiResponse.Result = _mapper.Map<IEnumerable<CouponDto>>(coupons);
        }
        catch (Exception ex)
        {
            _apiResponse.IsSuccess = false;
            _apiResponse.Message = ex.Message;
        }

        return _apiResponse;
    }
    
    [HttpGet("{id:int}")]
    public async Task<ApiResponse> GetAsync(int id)
    {
        try
        {
            var coupon = await _dbContext.Coupons.FirstAsync(f => f.Id == id);
            _apiResponse.Result = _mapper.Map<CouponDto>(coupon);
        }
        catch (Exception ex)
        {
            _apiResponse.IsSuccess = false;
            _apiResponse.Message = ex.Message;
        }

        return _apiResponse;
    }

    [HttpGet("getByCode/{code}")]
    public async Task<ApiResponse> GetByCodeAsync(string code)
    {
        try
        {
            var coupon = await _dbContext.Coupons.FirstAsync(f => f.Code.ToLower() == code.ToLower());
            _apiResponse.Result = _mapper.Map<CouponDto>(coupon);
        }
        catch (Exception ex)
        {
            _apiResponse.IsSuccess = false;
            _apiResponse.Message = ex.Message;
        }
        
        return _apiResponse;
    }

    [HttpPost]
    public async Task<ApiResponse> PostAsync([FromBody] CouponDto dto)
    {
        try
        {
            var coupon = _mapper.Map<Coupon>(dto);
            
            await _dbContext.Coupons.AddAsync(coupon);
            await _dbContext.SaveChangesAsync();
            
            _apiResponse.Result = _mapper.Map<CouponDto>(coupon);
        }
        catch (Exception ex)
        {
            _apiResponse.IsSuccess = false;
            _apiResponse.Message = ex.Message;
        }

        return _apiResponse;
    }
    
    [HttpPut]
    public async Task<ApiResponse> PutAsync([FromBody] CouponDto dto)
    {
        try
        {
            var coupon = _mapper.Map<Coupon>(dto);
            
            _dbContext.Coupons.Update(coupon);
            await _dbContext.SaveChangesAsync();
            
            _apiResponse.Result = _mapper.Map<CouponDto>(coupon);
        }
        catch (Exception ex)
        {
            _apiResponse.IsSuccess = false;
            _apiResponse.Message = ex.Message;
        }

        return _apiResponse;
    }
    
    [HttpDelete("{id:int}")]
    public async Task<ApiResponse> DeleteAsync(int id, CancellationToken cancellationToken)
    {
        try
        {
            var coupon = await _dbContext.Coupons.FirstAsync(f => f.Id == id, cancellationToken: cancellationToken);
            
            _dbContext.Coupons.Remove(coupon);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            _apiResponse.IsSuccess = false;
            _apiResponse.Message = ex.Message;
        }

        return _apiResponse;
    }
}
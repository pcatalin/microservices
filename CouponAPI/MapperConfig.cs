using AutoMapper;
using CouponAPI.Models;
using CouponAPI.Models.Dto;

namespace CouponAPI;

public class MapperConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mapConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<CouponDto, Coupon>();
            config.CreateMap<Coupon, CouponDto>();
        });

        return mapConfig;
    }
}
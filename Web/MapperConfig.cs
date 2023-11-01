using AutoMapper;
using Web.Models.Dto;

namespace Web;

public class MapperConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mapConfig = new MapperConfiguration(config =>
        {
            config.CreateMap<object, CouponDto>();
        });

        return mapConfig;
    }
}
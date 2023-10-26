namespace Web.Utils;

public class ApiUtils : IApiUtils
{
    public ICouponApiInfo CouponApiInfo { get; set; }
}

public class CouponApiInfo : ICouponApiInfo
{
    public required string HttpClientName { get; init; }
    public required string CouponBaseUrl { get; init; }
}
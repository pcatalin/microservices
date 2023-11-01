namespace Web.Utils;

public class ApiUtils : IApiUtils
{
    public IApiInfo CouponApiInfo { get; set; }
}

public class CouponApiInfo : IApiInfo
{
    public required string HttpClientName { get; init; }
    public required string BaseUrl { get; init; }
}
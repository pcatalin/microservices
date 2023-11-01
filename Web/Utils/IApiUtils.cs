namespace Web.Utils;

public interface IApiUtils
{
    IApiInfo CouponApiInfo { get; }
}

public interface IApiInfo
{
    string HttpClientName { get; }
    string BaseUrl { get; }
}
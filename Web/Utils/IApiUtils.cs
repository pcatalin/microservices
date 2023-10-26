namespace Web.Utils;

public interface IApiUtils
{
    ICouponApiInfo CouponApiInfo { get; }
}

public interface ICouponApiInfo
{
    string HttpClientName { get; }
    string CouponBaseUrl { get; }
}
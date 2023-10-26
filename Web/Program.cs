using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Web;
using Web.Service;
using Web.Service.Interface;
using Web.Utils;
using Web.Utils.Settings;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IRequestService, RequestService>();
builder.Services.AddScoped<ICouponService, CouponService>();

RegisterApiUtils();

await builder.Build().RunAsync();

void RegisterApiUtils()
{
     var serviceUrlSettings = builder.Configuration.GetSection(nameof(ServiceUrlSettings));
     var urlSettings = serviceUrlSettings.Get<ServiceUrlSettings>() ?? new ServiceUrlSettings();
     
     if (urlSettings is null)
     {
          throw new NotImplementedException("Service Url Settings is missing from configuration");
     }

     var apiUtils = new ApiUtils();

     if (!string.IsNullOrWhiteSpace(urlSettings.CouponAPI))
     {
          var couponApiInfo = new CouponApiInfo
          {
               HttpClientName = nameof(ServiceUrlSettings.CouponAPI),
               CouponBaseUrl = urlSettings.CouponAPI
          };
          apiUtils.CouponApiInfo = couponApiInfo;
     }

     // register http clients
     foreach (var prop in urlSettings.GetType().GetProperties())
     {
          var propName = prop.Name;
          builder.Services.AddHttpClient(propName);
     }
     
     builder.Services.AddSingleton<IApiUtils>(apiUtils);
}
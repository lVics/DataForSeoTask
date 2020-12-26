using DataForSeo.BusinessLogic.Interfaces;
using DataForSeo.BusinessLogic.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataForSeo.BusinessLogic.InjectionModules
{
  public static class BusinessLogicExtension
  {
    public static void ConfigureBusinessLogic(this IServiceCollection services, IConfiguration configuration)
    {
      services.AddScoped<ISERPRegularService, SERPRegularService>();
    }
  }
}

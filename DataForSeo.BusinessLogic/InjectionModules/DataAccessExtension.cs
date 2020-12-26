using DataForSeo.DataAccess.Interfaces;
using DataForSeo.DataAccess.Repositories.Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataForSeo.BusinessLogic.InjectionModules
{
  public static class DataAccessExtension
  {
    public static void ConfigureDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
      string connectionString = configuration.GetConnectionString("ConnectionString");

      services.AddScoped<ISERPRegularRepository, SERPRegularRepository>(provider => new SERPRegularRepository(connectionString));
    }
  }
}

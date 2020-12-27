using DataForSeo.Shared.APIModels;
using DataForSeo.Shared.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace DataForSeo.Shared.Managers
{
  public static partial class Demos
  {
    public static async Task<IEnumerable<LocationResultItem>> serp_locations()
    {
      var httpClient = get_authorize_client("https://api.dataforseo.com/");

      var response = await httpClient.GetAsync("/v3/serp/google/locations");
      var result = JsonConvert.DeserializeObject<LocationsModel>(await response.Content.ReadAsStringAsync());
      if (result.status_code == 20000)
      {
        return result.tasks.SelectMany(x => x.result);
      }
      else
        throw new Exception($"code: {result.status_code}  message: {result.status_message}");
    }


    private static HttpClient get_authorize_client(string baseUrl)
    {
      return  new HttpClient
      {
        BaseAddress = new Uri(baseUrl),
        DefaultRequestHeaders = {
          Authorization = new AuthenticationHeaderValue(
            "Basic",
            Convert.ToBase64String(
              Encoding.ASCII.GetBytes(
                $"{Credentials.UserName}:{Credentials.Password}"
                )
              )
            )
        }
      };
    }
  }
}

using DataForSeo.Shared.APIModels;
using DataForSeo.Shared.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DataForSeo.Shared.Managers
{
  public static partial class Demos
  {
    public static async Task<IEnumerable<LocationResultItem>> SERPGetLocations()
    {
      var httpClient = GetAuthorizeClient(baseUrl: "https://api.dataforseo.com/");

      var response = await httpClient.GetAsync("/v3/serp/google/locations");
      var result = JsonConvert.DeserializeObject<LocationsModel>(await response.Content.ReadAsStringAsync());
      if (result.status_code == 20000)
      {
        return result.tasks.SelectMany(x => x.result);
      }
      else
        throw new Exception($"code: {result.status_code}  message: {result.status_message}");
    }

    public static async Task<int> SERPGetSiteRank(LiveRegularModelRequest model)
    {
      var httpClient = GetAuthorizeClient(baseUrl: "https://api.dataforseo.com/");
      var postData = new List<object>();
      postData.Add(new
      {
        model.language_code,
        model.location_code,
        keyword = Regex.Replace(model.keyword, @"\t|\n|\r", "").Replace("%","%25")
      });

      var taskPostResponse = await httpClient.PostAsync($"/v3/serp/{model.search_engine.ToLower()}/organic/live/regular", new StringContent(JsonConvert.SerializeObject(postData)));
      var result = JsonConvert.DeserializeObject<dynamic>(await taskPostResponse.Content.ReadAsStringAsync());

      if (result.status_code == 20000)
      {
        var tasks = (IEnumerable<dynamic>)result?.tasks;
        var results = tasks?.Where(x => x?.result != null)
                            .SelectMany<dynamic, dynamic>(x => x.result);
        var items = results?.Where(x => x?.items != null)
                            .SelectMany<dynamic, dynamic>(x => x.items);
        var currentItem = items?.Where(x => x?.url != null)
                                .FirstOrDefault(x => x.url.ToString().Contains(model.website));
        return currentItem is null ? 0 : currentItem.rank_group;
      }
      else
        throw new Exception($"code: {result.status_code}  message: {result.status_message}");
    }

    private static HttpClient GetAuthorizeClient(string baseUrl)
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

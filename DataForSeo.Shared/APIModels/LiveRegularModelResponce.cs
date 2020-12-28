using System.Collections.Generic;

namespace DataForSeo.Shared.APIModels
{
  public class cModelResponce
  {
    public string version { get; set; }
    public int status_code { get; set; }
    public string status_message { get; set; }
    public string time { get; set; }
    public float cost { get; set; }
    public int tasks_count { get; set; }
    public int tasks_error { get; set; }
    public List<LiveRegularTask> tasks { get; set; }
  }

  public class LiveRegularTask
  {
    public string id { get; set; }
    public int status_code { get; set; }
    public string status_message { get; set; }
    public string time { get; set; }
    public float cost { get; set; }
    public string result_count { get; set; }
    public List<string> path { get; set; }
    public List<string> data { get; set; }
    public List<LiveRegularTaskResult> result { get; set; }
  }

  public class LiveRegularTaskResult
  {
    public string keyword { get; set; }
    public string type { get; set; }
    public string se_domain { get; set; }
    public string location_code { get; set; }
    public string language_code { get; set; }
    public string check_url { get; set; }
    public string datetime { get; set; }
    public List<LiveRegularSpells> spell { get; set; }
    public List<string> item_types { get; set; }
    public int se_results_count { get; set; }
    public int items_count { get; set; }
    public List<string> items { get; set; }
  }

  public class LiveRegularSpells
  {
    public string keyword { get; set; }
    public string type { get; set; }
  }
}

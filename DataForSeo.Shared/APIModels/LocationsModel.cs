using System.Collections.Generic;

namespace DataForSeo.Shared.APIModels
{
  public class LocationsModel
  {
    public string version { get; set; }
    public int status_code { get; set; }
    public string status_message { get; set; }
    public string time { get; set; }
    public float cost { get; set; }
    public int tasks_count { get; set; }
    public int tasks_error { get; set; }
    public List<LocationTaskItem> tasks { get; set; }
  }

  public class LocationTaskItem
  {
    public string id { get; set; }
    public int status_code { get; set; }
    public string status_message { get; set; }
    public string time { get; set; }
    public float cost { get; set; }
    public int result_count { get; set; }
    public List<string> path { get; set; }
    public List<LocationDataItem> data { get; set; }
    public List<LocationResultItem> result { get; set; }
  }

  public class LocationDataItem
  {
    public string api { get; set; }
    public string function { get; set; }
    public string se { get; set; }
  }

  public class LocationResultItem
  {
    public int location_code { get; set; }
    public string location_name { get; set; }
    public int? location_code_parent { get; set; }
    public string country_iso_code { get; set; }
    public string location_type { get; set; }
  }
}

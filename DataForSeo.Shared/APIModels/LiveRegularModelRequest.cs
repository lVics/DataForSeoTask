using System;
using System.Collections.Generic;
using System.Text;

namespace DataForSeo.Shared.APIModels
{
  public class LiveRegularModelRequest
  {
    public string language_code { get; set; }
    public int location_code { get; set; }
    public string keyword { get; set; }
    public string website { get; set; }
    public string search_engine { get; set; }
  }
}

using DataForSeo.BusinessLogic.DTOModels;
using DataForSeo.Shared.Enums;
using System.Collections.Generic;

namespace DataForSeo.SERPRegular.ViewModels
{
  public class SERPRegularViewModel
  {
    public IEnumerable<SERPRegularDTO> SERPRegulars { get; set; }
    public IEnumerable<LocationViewItem> Locations { get; set; }
    public IEnumerable<string> SearchEngines { get; set; }
  }

  public class LocationViewItem
  {
    public int location_code { get; set; }
    public string location_name { get; set; }
  }
}

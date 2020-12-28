using DataForSeo.Shared.Enums;

namespace DataForSeo.BusinessLogic.DTOModels
{
  public class SERPRegularDTO
  {
    public string Keyword { get; set; }
    public string Website { get; set; }
    public string Location { get; set; }
    public SearchEngine SearchEngine { get; set; }
    public int Rank_group { get; set; }
  }
}

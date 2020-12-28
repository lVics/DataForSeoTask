using DataForSeo.BusinessLogic.DTOModels;
using DataForSeo.BusinessLogic.Interfaces;
using DataForSeo.SERPRegular.ViewModels;
using DataForSeo.Shared.APIModels;
using DataForSeo.Shared.Enums;
using DataForSeo.Shared.Managers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataForSeoSERPRegilar.Controllers
{
  public class HomeController : Controller
  {
    ISERPRegularService _SERPRegularService;

    public HomeController(ISERPRegularService SERPRegularService)
    {
      _SERPRegularService = SERPRegularService;
    }

    public async Task<IActionResult> Index()
    {
      var model = new SERPRegularViewModel();
      model.SERPRegulars = await _SERPRegularService.GetAllAsync();
      model.SearchEngines = Enum.GetNames(typeof(SearchEngine)).Cast<string>().ToList();
      model.Locations = (await Demos.SERPGetLocations()).Select(location =>
      {
        return new LocationViewItem()
        {
          location_code = location.location_code,
          location_name = location.location_name
        };
      });
      return View(model);
    }

    [HttpPost]
    [Route("Search")]
    public async Task<IActionResult> Search(SERPRegularDTO model)
    {
      model.Rank_group = await Demos.SERPGetSiteRank(new LiveRegularModelRequest() 
      {
        keyword = model.Keyword,
        website = model.Website,
        language_code = "en",
        location_code = model.Location,
        search_engine = model.SearchEngine

      });
      await _SERPRegularService.CreateAsync(model);
      return RedirectToAction("Index");
    }
  }
}

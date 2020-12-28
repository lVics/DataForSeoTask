using DataForSeo.BusinessLogic.DTOModels;
using DataForSeo.BusinessLogic.Interfaces;
using DataForSeo.SERPRegular.ViewModels;
using DataForSeo.Shared.Enums;
using DataForSeo.Shared.Managers;
using Microsoft.AspNetCore.Mvc;
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
      //Enum.GetValues(typeof(Foos)).Cast<Foos>()
      model.SearchEngines = new List<SearchEngine>() { SearchEngine.Google, SearchEngine.Bing };
      model.Locations = (await Demos.serp_locations()).Select(location =>
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
      //model.Rank_group = await Demos.serp_live_regular(model);
      await _SERPRegularService.CreateAsync(model);
      return RedirectToAction("Index");
    }
  }
}

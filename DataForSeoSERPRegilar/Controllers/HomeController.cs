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
      model.SearchEngines = new List<SearchEngine>() { SearchEngine.Google, SearchEngine.Bing };
      //model.Locations = (await Demos.serp_locations()).Select(location =>
      //{
      //  return new LocationViewItem()
      //  {
      //    location_code = location.location_code,
      //    location_name = location.location_name
      //  };
      //});
      model.Locations = new List<LocationViewItem>() 
      {
        new LocationViewItem()
        {
          location_code = 1,
          location_name = "Location1"
        },
        new LocationViewItem()
        {
          location_code = 2,
          location_name = "Location2"
        },
        new LocationViewItem()
        {
          location_code = 3,
          location_name = "Location3"
        }
    };
      return View(model);
    }
  }
}

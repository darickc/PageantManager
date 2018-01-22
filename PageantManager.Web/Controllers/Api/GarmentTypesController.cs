using Microsoft.AspNetCore.Mvc;

namespace PageantManager.Web.Controllers.Api
{
  public class GarmentTypesController : Controller
  {
    // GET
    public IActionResult Index()
    {
      return
      View();
    }
  }
}

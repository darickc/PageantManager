using Microsoft.AspNetCore.Mvc;

namespace PageantManager.Web.Controllers.Api
{
  public class GarmentController : Controller
  {
    // GET
    public IActionResult Index()
    {
      return
      View();
    }
  }
}

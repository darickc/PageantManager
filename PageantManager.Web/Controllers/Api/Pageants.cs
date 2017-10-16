using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PageantManager.Business.Business;
using PageantManager.Business.Models;

namespace PageantManager.Web.Controllers.Api
{
  [Produces("application/json")]
  [Route("api/pageants")]
  public class PageantsController : Controller
  {
    private readonly PageantsBusiness _pageantsBusiness;

    public PageantsController(PageantsBusiness pageantsBusiness)
    {
      _pageantsBusiness = pageantsBusiness;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var pageants = await _pageantsBusiness.GetPageants();
      return Ok(new ItemsModel<PageantModel>(pageants));
    }
    // GET
//    public IActionResult Index()
//    {
//      return
//      View();
//    }
  }
}

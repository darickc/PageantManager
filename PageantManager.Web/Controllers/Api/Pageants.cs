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

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PageantModel model)
    {
      if (ModelState.IsValid)
      {
        model = await _pageantsBusiness.UpdatePageant(model);
        return Ok(model);
      }
      return BadRequest(ModelState.Values);
    }
    // GET
//    public IActionResult Index()
//    {
//      return
//      View();
//    }
  }
}

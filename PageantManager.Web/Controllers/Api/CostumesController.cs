using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PageantManager.Business.Business;
using PageantManager.Business.Models;

namespace PageantManager.Web.Controllers.Api
{
  [Produces("application/json")]
  [Route("api/pageants")]
  public class CostumesController : Controller
  {
    private readonly CostumesBusiness _costumesBusiness;

    public CostumesController(CostumesBusiness costumesBusiness)
    {
      _costumesBusiness = costumesBusiness;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CostumeModel model)
    {
      if (ModelState.IsValid)
      {
        model = await _costumesBusiness.UpdateCostume(model);
        return Ok(model);
      }
      return BadRequest(ModelState.ValidationState);
    }

//    public IActionResult Index()
//    {
//      return
//      View();
//    }
  }
}

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
    private readonly PerformancesBusiness _performancesBusiness;
    private readonly CostumesBusiness _costumesBusiness;

    public PageantsController(PageantsBusiness pageantsBusiness, PerformancesBusiness performancesBusiness)
    {
      _pageantsBusiness = pageantsBusiness;
      _performancesBusiness = performancesBusiness;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      var pageants = await _pageantsBusiness.GetPageants();
      return Ok(new ItemsModel<PageantModel>(pageants));
    }

    [HttpPut]
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

    [HttpGet("{id}/performances")]
    public async Task<IActionResult> GetPerformances(int id)
    {
      var performances = await _performancesBusiness.GetPerformances(id);
      return Ok(new ItemsModel<PerformanceModel>(performances));
    }

    [HttpGet("{id}/costumes")]
    public async Task<IActionResult> GetCostumes(int id)
    {
      var costumes = await _costumesBusiness.GetCostumes(id);
      return Ok(new ItemsModel<CostumeModel>(costumes));
    }
  }
}

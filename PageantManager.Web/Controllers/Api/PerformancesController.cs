//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using PageantManager.Business.Business;
//using PageantManager.Business.Models;
//
//namespace PageantManager.Web.Controllers.Api
//{
//  [Produces("application/json")]
//  [Route("api/performances")]
//  public class PerformancesController : Controller
//  {
//    private readonly PerformancesBusiness _performancesBusiness;
//
//    public PerformancesController(PerformancesBusiness performancesBusiness)
//    {
//      _performancesBusiness = performancesBusiness;
//    }
//
//    [HttpGet("{id}")]
//    public async Task<IActionResult> Get(int id)
//    {
//      var performance = await _performancesBusiness.GetPerformance(id);
//      return Ok(performance);
//    }
//
//    [HttpPost]
//    public async Task<IActionResult> Post([FromBody] PerformanceModel model)
//    {
//      if (ModelState.IsValid)
//      {
//        model = await _performancesBusiness.UpdatePerformance(model);
//        return Ok(model);
//      }
//      return BadRequest(ModelState.ValidationState);
//    }
//
//    [HttpDelete("{id}")]
//    public async Task<IActionResult> Delete(int id)
//    {
//      await _performancesBusiness.DeletePerformance(id);
//      return Ok();
//    }
//
//  }
//}

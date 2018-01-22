using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PageantManager.Business.Business;
using PageantManager.Business.Models;

namespace PageantManager.Web.Controllers.Api
{
  /// <summary>
  ///
  /// </summary>
  [Produces("application/json")]
  [Route("api/costumes")]
  public class CostumesController : Controller
  {
    private readonly CostumesBusiness _costumesBusiness;

    /// <summary>
    ///
    /// </summary>
    /// <param name="costumesBusiness"></param>
    public CostumesController(CostumesBusiness costumesBusiness)
    {
      _costumesBusiness = costumesBusiness;
    }

    /// <summary>
    /// Get Costumes
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<CostumeModel>), 200)]
    public async Task<IActionResult> Get()
    {
      var costumes = await _costumesBusiness.GetCostumes();
      return Ok(costumes);
    }

    /// <summary>
    /// Update/Create Costume
    /// </summary>
    /// <param name="measurements"></param>
    /// <returns></returns>
    [HttpPost("search")]
    [ProducesResponseType(typeof(List<CostumeModel>), 200)]
    public async Task<IActionResult> PostSearch([FromBody] List<MeasurementModel> measurements)
    {
      var costumes = await _costumesBusiness.SearchCostumes(measurements);
      return Ok(costumes);
    }

    /// <summary>
    /// Update/Create Costume
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [ProducesResponseType(typeof(CostumeModel), 200)]
    public async Task<IActionResult> Post([FromBody] CostumeModel model)
    {
      if (ModelState.IsValid)
      {
        model = await _costumesBusiness.UpdateCostume(model);
        return Ok(model);
      }
      return BadRequest(ModelState.ValidationState);
    }
  }
}

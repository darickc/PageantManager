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
  [Route("api/garment-types")]
  public class GarmentTypesController : Controller
  {
    private readonly GarmentTypesBusiness _garmentTypesBusiness;

    /// <summary>
    ///
    /// </summary>
    /// <param name="garmentTypesBusiness"></param>
    public GarmentTypesController(GarmentTypesBusiness garmentTypesBusiness)
    {
      _garmentTypesBusiness = garmentTypesBusiness;
    }

    /// <summary>
    /// Get Garment Types
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<GarmentTypeModel>), 200)]
    public async Task<IActionResult> Get()
    {
      var gt = await _garmentTypesBusiness.GetGarmentTypes();
      return Ok(gt);
    }

    /// <summary>
    /// Get Garment Type by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GarmentTypeModel), 200)]
    public async Task<IActionResult> Get(int id)
    {
      var gt = await _garmentTypesBusiness.GetGarmentType(id);
      return Ok(gt);
    }

    /// <summary>
    /// Update/Create Garment Type
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [HttpPut]
    [ProducesResponseType(typeof(GarmentTypeModel), 200)]
    public async Task<IActionResult> Post([FromBody] GarmentTypeModel model)
    {
      if (ModelState.IsValid)
      {
        model = await _garmentTypesBusiness.UpdateGarmentType(model);
        return Ok(model);
      }
      return BadRequest(ModelState.ValidationState);
    }
  }
}

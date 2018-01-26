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
  [Route("api/garments")]
  public class GarmentController : Controller
  {
    private readonly GarmentsBusiness _garmentsBusiness;

    /// <summary>
    ///
    /// </summary>
    /// <param name="garmentsBusiness"></param>
    public GarmentController(GarmentsBusiness garmentsBusiness)
    {
      _garmentsBusiness = garmentsBusiness;
    }

    /// <summary>
    /// Get Garment by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(GarmentModel), 200)]
    public async Task<IActionResult> Get(int id)
    {
      var garment = await _garmentsBusiness.GetGarmentModel(id);
      return Ok(garment);
    }

    /// <summary>
    /// Add/Update Garment
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [HttpPut]
    [ProducesResponseType(typeof(GarmentModel), 200)]
    public async Task<IActionResult> Post([FromBody] GarmentModel model)
    {
      if (ModelState.IsValid)
      {
        model = await _garmentsBusiness.UpdateGarment(model);
        return Ok(model);
      }
      return BadRequest(ModelState.ValidationState);
    }
  }
}

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
  [Route("api/meaurement_types")]
  public class MeasuremntTypesController : Controller
  {
    private readonly MeasurementTypesBusiness _measurementTypesBusiness;

    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="measurementTypesBusiness"></param>
    public MeasuremntTypesController(MeasurementTypesBusiness measurementTypesBusiness)
    {
      _measurementTypesBusiness = measurementTypesBusiness;
    }

    /// <summary>
    /// Get Measurement Types
    /// </summary>
    /// <returns></returns>
    [HttpGet]
    [ProducesResponseType(typeof(List<MeasurementTypeModel>), 200)]
    public async Task<IActionResult> Get()
    {
      var types = await _measurementTypesBusiness.GetMeasuremntTypes();
      return Ok(types);
    }

    /// <summary>
    /// Update/Create Measurement Type
    /// </summary>
    /// <param name="mtm"></param>
    /// <returns></returns>
    [HttpPost]
    [HttpPut]
    [ProducesResponseType(typeof(MeasurementTypeModel), 200)]
    public async Task<IActionResult> Post([FromBody] MeasurementTypeModel mtm)
    {
      mtm = await _measurementTypesBusiness.UpdateMeasuremntType(mtm);
      return Ok(mtm);
    }
  }
}

﻿using System.Collections.Generic;
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
    [ProducesResponseType(typeof(ItemsModel<CostumeModel>), 200)]
    public async Task<IActionResult> Get([FromQuery] string search = null, [FromQuery] int? page = 1, [FromQuery] int? pageCount = 25)
    {
      if (!page.HasValue)
        page = 1;
      if (!pageCount.HasValue)
        pageCount = 25;
      var costumes = await _costumesBusiness.GetCostumes(search, page.Value, pageCount.Value);
      return Ok(costumes);
    }

    /// <summary>
    /// Get Costume by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id:int}")]
    [ProducesResponseType(typeof(CostumeModel), 200)]public async Task<IActionResult> Get(int id)
    {
      var costume = await _costumesBusiness.GetCostumeModel(id);
      return Ok(costume);
    }

    /// <summary>
    /// Search form Costumes that fit the measurements
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
    /// Get costume and garments that fit the measurements
    /// </summary>
    /// <param name="id"></param>
    /// <param name="measurements"></param>
    /// <returns></returns>
    [HttpPost("search/{id:int}")]
    [ProducesResponseType(typeof(List<CostumeModel>), 200)]
    public async Task<IActionResult> PostSearch(int id, [FromBody] List<MeasurementModel> measurements)
    {
      var costumes = await _costumesBusiness.GetCostume(id, measurements);
      return Ok(costumes);
    }

    /// <summary>
    /// Update/Create Costume
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [HttpPost]
    [HttpPut]
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

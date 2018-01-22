using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PageantManager.Business.Entities;
using PageantManager.Business.Models;

namespace PageantManager.Business.Business
{
    public class CostumesBusiness
    {
		readonly PageantManagerContext _ctx;

		public CostumesBusiness(PageantManagerContext ctx)
		{
			_ctx = ctx;
		}
	    
//	    public async Task<List<CostumeModel>> GetCostumes(int pageantId)
//	    {
//		    var costumes = await _ctx.Costumes.Where(c=>c.PageantId == pageantId).OrderBy(g => g.Description).ToListAsync();
//		    return Mapper.Map<List<CostumeModel>>(costumes);
//	    }

	    public async Task<List<CostumeModel>> SearchCostumes(List<MeasurementModel> measurements)
	    {
		    var costumes = await _ctx.Costumes.Where(c => 
		    	c.CostumeGarments.All(cg=> cg.GarmentType.Garments.Any(g => !g.CheckedOut && 
					g.GarmentMeasurements.All(m=> measurements.Any(m2 => 
						m.MeasurementTypeId == m2.MeasurementType.MeasurementTypeId &&
						m.Min <= m2.Value && m2.Value <= m.Max))))).ToListAsync();

		    return Mapper.Map<List<CostumeModel>>(costumes);
	    }
	    
	    public async Task<List<CostumeModel>> GetCostumes()
	    {
		    var costumes = await _ctx.Costumes.OrderBy(g => g.Name).ToListAsync();
		    return Mapper.Map<List<CostumeModel>>(costumes);
	    }

	    public async Task<CostumeModel> GetCostume(int id, List<MeasurementModel> measurements)
	    {
		    var costume = await _ctx.Costumes.Include(c => c.CostumeGarments)
			    .ThenInclude(cg => cg.GarmentType)
			    .ThenInclude(ct => ct.Garments)
			    .ThenInclude(g => g.GarmentMeasurements)
			    .ThenInclude(gm => gm.MeasurementType)
			    .SingleOrDefaultAsync(c => c.CostumeId == id);

		    if (costume != null)
		    {
			    foreach (var costumeGarment in costume.CostumeGarments)
			    {
				    costumeGarment.GarmentType.Garments = costumeGarment.GarmentType.Garments.Where(g =>
					    !g.CheckedOut && g.GarmentMeasurements.All(m => measurements.Any(m2 =>
						    m.MeasurementTypeId == m2.MeasurementType.MeasurementTypeId &&
						    m.Min <= m2.Value && m2.Value <= m.Max))).ToList();
			    }
			    return Mapper.Map<CostumeModel>(costume);
		    }
		    return null;
	    }
	    
	    public async Task<CostumeModel> UpdateCostume(CostumeModel model)
	    {
		    var costume = await _ctx.Costumes.FindAsync(model.CostumeId);
		    if(costume == null)
		    {
			    costume = new Costume();
			    _ctx.Costumes.Add(costume);
		    }
		    Mapper.Map(model, costume);

		    await _ctx.SaveChangesAsync();

		    return model;
	    }
	    
	    public async Task DeleteCostume(int id)
	    {
		    var costume = await _ctx.Costumes.FindAsync(id);
		    _ctx.Costumes.Remove(costume);
		    await _ctx.SaveChangesAsync();
	    }
    }
}

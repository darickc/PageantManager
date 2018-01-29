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
    public class GarmentsBusiness
    {
		readonly PageantManagerContext _ctx;

		public GarmentsBusiness(PageantManagerContext ctx)
		{
			_ctx = ctx;
		}
	    
	    public async Task<List<GarmentModel>> GetGarments()
	    {
		    var garments = await _ctx.Garments.ToListAsync();
		    return Mapper.Map<List<GarmentModel>>(garments);
	    }

	    public async Task<GarmentModel> GetGarmentModel(int id)
	    {
		    var garment = await GetGarment(id);
		    return Mapper.Map<GarmentModel>(garment);
	    }
	    
	    public async Task<GarmentModel> UpdateGarment(GarmentModel model)
	    {
		    var garment = await GetGarment(model.GarmentId);
		    if (garment == null)
		    {
			    garment = new Garment
			    {
				    GarmentMeasurements = new List<GarmentMeasurement>()
			    };
			    model.AddedDate = DateTime.UtcNow;
			    _ctx.Garments.Add(garment);
		    }
		    _ctx.Entry(garment).CurrentValues.SetValues(model);
		    
		    foreach (var garmentMeasurement in model.GarmentMeasurements)
		    {
			    garmentMeasurement.MeasurementType = null;
			    if (garmentMeasurement.GarmentMeasurementId == 0)
			    {
				    garment.GarmentMeasurements.Add(Mapper.Map<GarmentMeasurement>(garmentMeasurement));
			    }
			    else
			    {
				    var mt = garment.GarmentMeasurements.SingleOrDefault(t =>
					    t.GarmentMeasurementId == garmentMeasurement.GarmentMeasurementId);
				    if (mt != null)
				    {
					    _ctx.Entry(mt).CurrentValues.SetValues(garmentMeasurement);
				    }
			    }
		    }

		    await _ctx.SaveChangesAsync();

		    return await GetGarmentModel(garment.GarmentId);
	    }
	    
	    public async Task DeleteGarment(int id)
	    {
		    var garment = await _ctx.Garments.FindAsync(id);
		    _ctx.Garments.Remove(garment);
		    await _ctx.SaveChangesAsync();
	    }

	    private async Task<Garment> GetGarment(int id)
	    {
		    var garment = await _ctx.Garments
			    .Include(g => g.GarmentMeasurements)
			    .ThenInclude(gm => gm.MeasurementType)
			    .SingleOrDefaultAsync(g => g.GarmentId == id);
		    return garment;
	    }
    }
}

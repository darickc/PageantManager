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
		    if(garment == null)
		    {
			    garment = new Garment
			    {
				    AddedDate = DateTime.UtcNow
			    };
			    _ctx.Garments.Add(garment);
		    }
		    Mapper.Map(model, garment);

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

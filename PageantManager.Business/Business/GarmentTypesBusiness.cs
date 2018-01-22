using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PageantManager.Business.Entities;
using PageantManager.Business.Models;

namespace PageantManager.Business.Business
{
    public class GarmentTypesBusiness
    {
		readonly PageantManagerContext _ctx;

		public GarmentTypesBusiness(PageantManagerContext ctx)
		{
			_ctx = ctx;
		}

	    public async Task<List<GarmentTypeModel>> GetGarmentTypes()
	    {
		    var garmentTypes = await _ctx.GarmentTypes.OrderBy(g => g.Name).ToListAsync();
		    return Mapper.Map<List<GarmentTypeModel>>(garmentTypes);
	    }

	    public async Task<GarmentTypeModel> GetGarmentType(int id)
	    {
		    var garmentType = await _ctx.GarmentTypes
			    .Include(gt => gt.GarmentMeasurementTypes)
			    .Include(t=>t.GarmentMeasurementTypes)
			    .SingleOrDefaultAsync(gt => gt.GarmentTypeId == id);
		    return Mapper.Map<GarmentTypeModel>(garmentType);
	    }
	    
	    public async Task<GarmentTypeModel> UpdateGarmentType(GarmentTypeModel model)
	    {
		    var garmentType = await _ctx.GarmentTypes.FindAsync(model.GarmentTypeId);
		    if(garmentType == null)
		    {
			    garmentType = new GarmentType();
			    _ctx.GarmentTypes.Add(garmentType);
		    }
		    Mapper.Map(model, garmentType);

		    await _ctx.SaveChangesAsync();

		    return model;
	    }
	    
	    public async Task DeleteGarmentType(int id)
	    {
		    var garmentType = await _ctx.GarmentTypes.FindAsync(id);
		    _ctx.GarmentTypes.Remove(garmentType);
		    await _ctx.SaveChangesAsync();
	    }
    }
}

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
	    
	    public async Task<ItemsModel<GarmentTypeModel>> GetGarmentTypes(string search, int page, int pageCount)
	    {
		    var q = GetGarmentTypesQuery(search);
		    var model = new ItemsModel<GarmentTypeModel>
		    {
			    Count = await q.CountAsync(),
			    Page = page,
			    PageCount = pageCount
		    };
		    
		    if ((page - 1) * pageCount >= model.Count)
		    {
			    model.Page = model.Count / pageCount;
			    if (model.Count % pageCount > 0)
				    model.Page++;
		    }

		    var garmentTypes = await q
			    .Skip((model.Page - 1) * pageCount)
			    .Take(pageCount)
			    .ToListAsync();
		    model.Items = Mapper.Map<List<GarmentTypeModel>>(garmentTypes);
		    return model;
	    }

	    private IOrderedQueryable<GarmentType> GetGarmentTypesQuery(string search)
	    {
		    var q = _ctx.GarmentTypes
			    .Where(c=> string.IsNullOrEmpty(search) || c.Name.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) > -1)
			    .OrderBy(g => g.Name);
		    return q;
	    }

	    public async Task<GarmentTypeModel> GetGarmentType(int id, bool includeGarments = false)
	    {
		    var q = _ctx.GarmentTypes
			    .Include(gt => gt.GarmentMeasurementTypes)
			    .ThenInclude(gmt=>gmt.MeasurementType)
			    .AsQueryable();

		    if (includeGarments)
		    {
			    q = q.Include(gt => gt.Garments)
				    .ThenInclude(g=>g.GarmentMeasurements)
				    .ThenInclude(g=>g.MeasurementType);
		    }
		    
		    var garmentType = await q.SingleOrDefaultAsync(gt => gt.GarmentTypeId == id);
		    return Mapper.Map<GarmentTypeModel>(garmentType);
	    }
	    
	    public async Task<GarmentTypeModel> UpdateGarmentType(GarmentTypeModel model)
	    {
		    
		    var garmentType = await _ctx.GarmentTypes
			    .Include(gt => gt.GarmentMeasurementTypes)
			    .SingleOrDefaultAsync(gt => gt.GarmentTypeId == model.GarmentTypeId);
		    if(garmentType == null)
		    {
			    garmentType = new GarmentType
			    {
				    GarmentMeasurementTypes = new List<GarmentMeasurementType>()
			    };
			    _ctx.GarmentTypes.Add(garmentType);
		    }
		    _ctx.Entry(garmentType).CurrentValues.SetValues(model);
		    //Mapper.Map(model, garmentType);

		    foreach (var measurementTypeModel in model.GarmentMeasurementTypes)
		    {
			    if (measurementTypeModel.GarmentMeasurementTypeId == 0)
			    {
			    	// garmentType.GarmentMeasurementTypes.Add(Mapper.Map<GarmentMeasurementType>(measurementTypeModel));
				    garmentType.GarmentMeasurementTypes.Add(new GarmentMeasurementType
				    {
					    MeasurementTypeId = measurementTypeModel.MeasurementTypeId
				    });
			    }
			    else
			    {
				    var mt = garmentType.GarmentMeasurementTypes.SingleOrDefault(t =>
					    t.GarmentMeasurementTypeId == measurementTypeModel.GarmentMeasurementTypeId);
				    if (mt != null)
				    {
					    _ctx.Entry(mt).CurrentValues.SetValues(measurementTypeModel);
				    }
			    }
		    }
		    
		    var ids = model.GarmentMeasurementTypes.Select(mt => mt.GarmentMeasurementTypeId).ToList();
		    _ctx.GarmentMeasurementTypes.RemoveRange(garmentType.GarmentMeasurementTypes.Where(mt=>!ids.Contains(mt.GarmentMeasurementTypeId)));

		    await _ctx.SaveChangesAsync();

		    return Mapper.Map<GarmentTypeModel>(garmentType);
	    }
	    
	    public async Task DeleteGarmentType(int id)
	    {
		    var garmentType = await _ctx.GarmentTypes.FindAsync(id);
		    _ctx.GarmentTypes.Remove(garmentType);
		    await _ctx.SaveChangesAsync();
	    }
    }
}

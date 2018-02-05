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
			    c.CostumeGarments.Count > 0 &&
		    	c.CostumeGarments.All(cg=> cg.GarmentType.Garments.Any(g => 
				    !g.CheckedOut && 
				    !g.RetiredDate.HasValue &&
					g.GarmentMeasurements.All(m=> 
						measurements.Any(m2 => 
						m.MeasurementTypeId == m2.MeasurementType.MeasurementTypeId &&
						m.Min <= m2.Value && 
						m2.Value <= m.Max))))).ToListAsync();

		    return Mapper.Map<List<CostumeModel>>(costumes);
	    }
	    
	    public async Task<ItemsModel<CostumeModel>> GetCostumes(string search, int page, int pageCount)
	    {
		    var q = GetCostumesQuery(search);
		    var model = new ItemsModel<CostumeModel>
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

		    var costumes = await q
			    .Skip((model.Page - 1) * pageCount)
			    .Take(pageCount)
			    .ToListAsync();
		    model.Items = Mapper.Map<List<CostumeModel>>(costumes);
		    return model;
	    }

	    private IOrderedQueryable<Costume> GetCostumesQuery(string search)
	    {
		    var q = _ctx.Costumes
			    .Where(c=> string.IsNullOrEmpty(search) || c.Name.IndexOf(search, StringComparison.CurrentCultureIgnoreCase) > -1)
			    .OrderBy(g => g.Name);
		    return q;
	    }
	    
	    public async Task<CostumeModel> GetCostumeModel(int id)
	    {
		    var costume = await GetCostume(id);
		    return costume != null ? Mapper.Map<CostumeModel>(costume) : null;
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
					    !g.CheckedOut && 
					    !g.RetiredDate.HasValue && 
					    g.GarmentMeasurements.All(m => measurements.Any(m2 =>
						    m.MeasurementTypeId == m2.MeasurementType.MeasurementTypeId &&
						    m.Min <= m2.Value && 
						    m2.Value <= m.Max))).ToList();
			    }
			    return Mapper.Map<CostumeModel>(costume);
		    }
		    return null;
	    }
	    
	    public async Task<CostumeModel> UpdateCostume(CostumeModel model)
	    {
		    var costume = await GetCostume(model.CostumeId);
		    
		    if(costume == null)
		    {
			    costume = new Costume
			    {
				    CostumeGarments = new List<CostumeGarment>()
			    };
			    _ctx.Costumes.Add(costume);
		    }
		    _ctx.Entry(costume).CurrentValues.SetValues(model);
		    
		    var ids = model.CostumeGarments.Where(mt => mt.CostumeGarmentId != 0).Select(mt =>  mt.CostumeGarmentId).ToList();
		    _ctx.CostumeGarments.RemoveRange(costume.CostumeGarments.Where(mt=>!ids.Contains(mt.CostumeGarmentId)));
		    
		    foreach (var costumeGarment in model.CostumeGarments.Where(cg=>cg.CostumeGarmentId == 0))
		    {
				costume.CostumeGarments.Add(new CostumeGarment()
				{
					GarmentTypeId = costumeGarment.GarmentTypeId
				});
		    }

		    await _ctx.SaveChangesAsync();

		    return await GetCostumeModel(costume.CostumeId);
	    }
	    
	    public async Task DeleteCostume(int id)
	    {
		    var costume = await _ctx.Costumes.FindAsync(id);
		    _ctx.Costumes.Remove(costume);
		    await _ctx.SaveChangesAsync();
	    }

	    private async Task<Costume> GetCostume(int id)
	    {
		    var costume = await _ctx.Costumes
			    .Include(c => c.CostumeGarments)
			    .ThenInclude(cg=>cg.GarmentType)
			    .SingleOrDefaultAsync(c => c.CostumeId == id);
		    return costume;
	    }
    }
}

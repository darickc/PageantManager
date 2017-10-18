using System;
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
	    
	    public async Task<CostumeModel> GetCostumes(int pageantId)
	    {
		    var costumes = await _ctx.Costumes.Where(c=>c.PageantId == pageantId).OrderBy(g => g.Description).ToListAsync();
		    return Mapper.Map<CostumeModel>(costumes);
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

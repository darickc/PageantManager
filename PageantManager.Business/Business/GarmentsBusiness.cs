using System;
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
	    
	    public async Task<GarmentModel> GetGarments()
	    {
		    var garments = await _ctx.Garments.ToListAsync();
		    return Mapper.Map<GarmentModel>(garments);
	    }
	    
	    public async Task<GarmentModel> UpdateGarment(GarmentModel model)
	    {
		    var garment = await _ctx.Garments.FindAsync(model.GarmentId);
		    if(garment == null)
		    {
			    garment = new Garment();
			    _ctx.Garments.Add(garment);
		    }
		    Mapper.Map(model, garment);

		    await _ctx.SaveChangesAsync();

		    return model;
	    }
	    
	    public async Task DeleteGarment(int id)
	    {
		    var garment = await _ctx.Garments.FindAsync(id);
		    _ctx.Garments.Remove(garment);
		    await _ctx.SaveChangesAsync();
	    }
    }
}

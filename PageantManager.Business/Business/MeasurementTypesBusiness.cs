using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PageantManager.Business.Entities;
using PageantManager.Business.Models;

namespace PageantManager.Business.Business
{
        public class MeasurementTypesBusiness
    {
        readonly PageantManagerContext _ctx;

        public MeasurementTypesBusiness(PageantManagerContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<List<MeasurementTypeModel>> GetMeasuremntTypes()
        {
            var types = await _ctx.MeasurementTypes.OrderBy(m => m.Name).ToListAsync();
            return Mapper.Map<List<MeasurementTypeModel>>(types);
        }
        
        public async Task<MeasurementTypeModel> UpdateMeasuremntType(MeasurementTypeModel model)
        {
            var mt = await _ctx.MeasurementTypes.FindAsync(model.MeasurementTypeId);
            if(mt == null)
            {
                mt = new MeasurementType();
                _ctx.MeasurementTypes.Add(mt);
            }
            Mapper.Map(model, mt);

            await _ctx.SaveChangesAsync();

            Mapper.Map(mt, model);
            return model;
        }
	    
//        public async Task DeleteMeasuremntType(int id)
//        {
//            var garment = await _ctx.Garments.FindAsync(id);
//            _ctx.Garments.Remove(garment);
//            await _ctx.SaveChangesAsync();
//        }
    }
}
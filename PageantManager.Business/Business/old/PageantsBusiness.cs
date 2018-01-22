//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using AutoMapper;
//using Microsoft.EntityFrameworkCore;
//using PageantManager.Business.Entities;
//using PageantManager.Business.Models;
//
//namespace PageantManager.Business.Business
//{
//    public class PageantsBusiness
//    {
//        readonly PageantManagerContext _ctx;
//
//        public PageantsBusiness(PageantManagerContext ctx)
//        {
//            _ctx = ctx;
//        }
//
//        public async Task<List<PageantModel>> GetPageants()
//        {
//            var pageants = await _ctx.Pageants.OrderBy(p => p.Name).ToListAsync();
//            return Mapper.Map<List<PageantModel>>(pageants);
//        }
//
//        public async Task<PageantModel> GetPageant(int id)
//        {
//            var pageant = await _ctx.Pageants.FindAsync(id);
//            return Mapper.Map<PageantModel>(pageant);
//        }
//
//        public async Task<PageantModel> UpdatePageant(PageantModel model)
//        {
//            var pageant = await _ctx.Pageants.FindAsync(model.PageantId);
//            if(pageant == null)
//            {
//                pageant = new Pageant();
//                _ctx.Pageants.Add(pageant);
//            }
//            Mapper.Map(model, pageant);
//
//            await _ctx.SaveChangesAsync();
//
//            return model;
//        }
//
//        public async Task DeletePageant(int id)
//        {
//            var pageant = await _ctx.Pageants.FindAsync(id);
//            _ctx.Pageants.Remove(pageant);
//            await _ctx.SaveChangesAsync();
//        }
//    }
//}

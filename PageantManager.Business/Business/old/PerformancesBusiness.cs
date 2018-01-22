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
//    public class PerformancesBusiness
//    {
//        readonly PageantManagerContext _ctx;
//
//        public PerformancesBusiness(PageantManagerContext ctx)
//        {
//            _ctx = ctx;
//        }
//
//		public async Task<List<PerformanceModel>> GetPerformances(int pageantId)
//		{
//			var performances = await _ctx.Performances.Where(p=>p.PageantId == pageantId).OrderBy(p => p.StartDate).ToListAsync();
//			return Mapper.Map<List<PerformanceModel>>(performances);
//		}
//
//		public async Task<PerformanceModel> GetPerformance(int id)
//		{
//			var performance = await _ctx.Performances.FindAsync(id);
//			return Mapper.Map<PerformanceModel>(performance);
//		}
//
//		public async Task<PerformanceModel> UpdatePerformance(PerformanceModel model)
//		{
//			var performance = await _ctx.Performances.FindAsync(model.PerformanceId);
//			if (performance == null)
//			{
//                performance = new Performance();
//				_ctx.Performances.Add(performance);
//			}
//			Mapper.Map(model, performance);
//
//			await _ctx.SaveChangesAsync();
//
//			return model;
//		}
//
//		public async Task DeletePerformance(int id)
//		{
//			var performance = await _ctx.Performances.FindAsync(id);
//			_ctx.Performances.Remove(performance);
//			await _ctx.SaveChangesAsync();
//		}
//    }
//}

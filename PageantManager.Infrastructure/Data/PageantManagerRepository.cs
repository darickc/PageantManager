using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PageantManager.Core.Entities;
using PageantManager.Core.Interfaces;

namespace PageantManager.Infrastructure.Data
{
    public class PageantManagerRepository<T> : IAsyncRepository<T>  where T : Entity
    {
        protected readonly PageantManagerContext _ctx;

        protected PageantManagerRepository(PageantManagerContext ctx)
        {
            _ctx = ctx;
        }


        public virtual async Task<T> GetByIdAsync(int id)
        {
            return await _ctx.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> ListAllAsync()
        {
            return await _ctx.Set<T>().ToListAsync();
        }

        public async Task<List<T>> ListAsync(ISpecification<T> spec)
        {
            var q = GetQueryable(spec);
            return await q.ToListAsync();
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            var q = GetQueryable(spec);
            return await q.CountAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            _ctx.Set<T>().Add(entity);
            await _ctx.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }
        
        public async Task DeleteAsync(T entity)
        {
            _ctx.Set<T>().Remove(entity);
            await _ctx.SaveChangesAsync();
        }

        protected IQueryable<T> GetQueryable(ISpecification<T> spec)
        {
            // fetch a Queryable that includes all expression-based includes
            var queryableResultWithIncludes = spec.Includes
                .Aggregate(_ctx.Set<T>().AsQueryable(),
                    (current, include) => current.Include(include));

            // modify the IQueryable to include any string-based include statements
            var secondaryResult = spec.IncludeStrings
                .Aggregate(queryableResultWithIncludes,
                    (current, include) => current.Include(include));

            return secondaryResult.Where(spec.Predicate);
        }
    }
}
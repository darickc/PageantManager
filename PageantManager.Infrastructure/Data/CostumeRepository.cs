using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PageantManager.Core.Entities;
using PageantManager.Core.Interfaces;
using PageantManager.Core.Specifications;

namespace PageantManager.Infrastructure.Data
{
    public class CostumeRepository : PageantManagerRepository<Costume>, ICostumeRepository
    {
        public CostumeRepository(PageantManagerContext ctx) : base(ctx)
        {
        }

        public async Task<int> GetFilteredCostumesCountAsync(string name)
        {
            var query = GetQueryable(new SearchCostumesByName(name));
            return await query.CountAsync();
        }

        public async Task<List<Costume>> GetFilteredAndPagedCostumesAsync(string name, int page, int countPerPage)
        {
            var query = GetQueryable(new SearchCostumesByName(name));
            return await query.Skip((page - 1) * countPerPage).Take(countPerPage).ToListAsync();
        }
    }
}
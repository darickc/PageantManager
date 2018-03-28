using System.Collections.Generic;
using System.Threading.Tasks;
using PageantManager.Core.Entities;

namespace PageantManager.Core.Interfaces
{
    public interface ICostumeRepository : IAsyncRepository<Costume>
    {
        Task<int> GetFilteredCostumesCountAsync(string name);
        Task<List<Costume>> GetFilteredAndPagedCostumesAsync(string name, int page, int countPerPage);
    }
}
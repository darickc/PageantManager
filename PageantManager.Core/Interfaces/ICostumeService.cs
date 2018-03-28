using System.Collections.Generic;
using System.Threading.Tasks;
using PageantManager.Core.Models;

namespace PageantManager.Core.Interfaces
{
    public interface ICostumeService
    {
        Task<List<CostumeModel>> SearchCostumes(List<MeasurementModel> measurements);
        Task<ItemsModel<CostumeModel>> GetCostumes(string search, int page, int pageCount);
    }
}
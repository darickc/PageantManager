using System.Collections.Generic;
using System.Threading.Tasks;
using PageantManager.Core.Models;

namespace PageantManager.Core.Interfaces
{
    public interface ICostumeService
    {
        Task<List<CostumeModel>> SearchCostumesByMeasurement(List<MeasurementModel> measurements);
        Task<ItemsModel<CostumeModel>> SearchCostumesByNameAndPage(string search, int page, int pageCount);
        Task<CostumeModel> GetCostumeByIdWithCostumeGarmentsAndGarmentTypes(int id);
        Task<CostumeModel> GetCostumeByIdAndFilterGarmentsByMeasurement(int id, List<MeasurementModel> measurements);
    }
}
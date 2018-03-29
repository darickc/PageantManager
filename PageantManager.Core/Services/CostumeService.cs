using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PageantManager.Core.Entities;
using PageantManager.Core.Interfaces;
using PageantManager.Core.Models;
using PageantManager.Core.Specifications;

namespace PageantManager.Core.Services
{
    public class CostumeService : ICostumeService
    {
        protected readonly ICostumeRepository CostumeRepository;
        protected readonly IAdapter Mapper;

        public CostumeService(ICostumeRepository costumeRepository, IAdapter mapper)
        {
            CostumeRepository = costumeRepository;
            Mapper = mapper;
        }

        public async Task<List<CostumeModel>> SearchCostumesByMeasurement(List<MeasurementModel> measurements)
        {
            var costumes = await CostumeRepository.ListAsync(new SearchCostumesByMeasurements(measurements));
            return Mapper.Map <List<CostumeModel>>(costumes);
        }

        public async Task<ItemsModel<CostumeModel>> SearchCostumesByNameAndPage(string search, int page, int pageCount)
        {
            var model = new ItemsModel<CostumeModel>
            {
                Count = await CostumeRepository.GetFilteredCostumesCountAsync(search),
                Page = page,
                PageCount = pageCount
            };
            
            if ((page - 1) * pageCount >= model.Count)
            {
                model.Page = model.Count / pageCount;
                if (model.Count % pageCount > 0)
                    model.Page++;
            }

            var costumes = await CostumeRepository.GetFilteredAndPagedCostumesAsync(search, model.Page, pageCount);
            
            model.Items = Mapper.Map<List<CostumeModel>>(costumes);

            return model;
        }

        public async Task<CostumeModel> GetCostumeByIdWithCostumeGarmentsAndGarmentTypes(int id)
        {
            var spec = new GetCostumeByIdWithCostumeGarmentsAndsGarmentTypesSpecification(id);
            var costume = (await CostumeRepository.ListAsync(spec)).FirstOrDefault();
            return costume != null ? Mapper.Map<CostumeModel>(costume) : null;
        }

        public async Task<CostumeModel> GetCostumeByIdAndFilterGarmentsByMeasurement(
            int id,
            List<MeasurementModel> measurements)
        {
            var spec = new  GetCostumeByIdAndIncludeAll(id);
            var costume = (await CostumeRepository.ListAsync(spec)).FirstOrDefault();
            if (costume != null)
            {
                foreach (var costumeGarment in costume.CostumeGarments)
                {
                    costumeGarment.GarmentType.Garments = costumeGarment.GarmentType.Garments.Where(g =>
                            !g.CheckedOut && 
                            !g.RetiredDate.HasValue && 
                            g.GarmentMeasurements.All(m => measurements.Any(m2 =>
                                m.MeasurementTypeId == m2.MeasurementType.MeasurementTypeId &&
                                m.Min <= m2.Value && 
                                m2.Value <= m.Max)))
                        .ToList();

                    foreach (var garment in costumeGarment.GarmentType.Garments)
                    {
                        garment.GarmentMeasurements = garment.GarmentMeasurements.OrderBy(g => g.MeasurementType.Name).ToList();
                    }
                }
                return Mapper.Map<CostumeModel>(costume);
            }

            return null;
        }
    }
}
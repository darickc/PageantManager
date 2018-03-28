using System.Collections.Generic;
using System.Threading.Tasks;
using PageantManager.Core.Entities;
using PageantManager.Core.Interfaces;
using PageantManager.Core.Models;
using PageantManager.Core.Specifications;

namespace PageantManager.Core.Services
{
    public class CostumeService : ICostumeService
    {
        protected readonly ICostumeRepository _costumeRepository;
        protected readonly IAdapter _mapper;

        public CostumeService(ICostumeRepository costumeRepository, IAdapter mapper)
        {
            _costumeRepository = costumeRepository;
            _mapper = mapper;
        }

        public async Task<List<CostumeModel>> SearchCostumes(List<MeasurementModel> measurements)
        {
            var costumes = await _costumeRepository.ListAsync(new SearchCostumesByMeasurements(measurements));
            return _mapper.Map <List<CostumeModel>>(costumes);
        }

        public async Task<ItemsModel<CostumeModel>> GetCostumes(string search, int page, int pageCount)
        {
            var model = new ItemsModel<CostumeModel>
            {
                Count = await _costumeRepository.GetFilteredCostumesCountAsync(search),
                Page = page,
                PageCount = pageCount
            };
            
            if ((page - 1) * pageCount >= model.Count)
            {
                model.Page = model.Count / pageCount;
                if (model.Count % pageCount > 0)
                    model.Page++;
            }

            var costumes = await _costumeRepository.GetFilteredAndPagedCostumesAsync(search, model.Page, pageCount);
            
            model.Items = _mapper.Map<List<CostumeModel>>(costumes);

            return model;
        }
    }
}
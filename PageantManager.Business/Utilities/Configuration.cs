using AutoMapper;
using PageantManager.Business.Entities;
using PageantManager.Business.Models;

namespace PageantManager.Business.Utilities
{
    public static class Configuration
	{
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.CreateMap<Pageant, PageantModel>().ReverseMap();
                x.CreateMap<Costume, CostumeModel>().ReverseMap();
                x.CreateMap<Garment, GarmentModel>().ReverseMap();
                x.CreateMap<GarmentType, GarmentTypeModel>().ReverseMap();
                x.CreateMap<Performance, PerformanceModel>().ReverseMap();
            });
        }

    }
}

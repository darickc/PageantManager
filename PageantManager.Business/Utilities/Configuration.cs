using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PageantManager.Business.Business;
using PageantManager.Business.Entities;
using PageantManager.Business.Models;

namespace PageantManager.Business.Utilities
{
    public static class Configuration
	{
        public static void Configure(IServiceCollection services)
        {
	        ConfigureMapper();
	        ConfigureDepenencies(services);
        }

	    private static void ConfigureMapper()
	    {
            Mapper.Initialize(x =>
            {
                x.CreateMap<Costume, CostumeModel>().ReverseMap();
                x.CreateMap<CostumeGarment, CostumeGarmentModel>().ReverseMap();
                x.CreateMap<Garment, GarmentModel>().ReverseMap();
                x.CreateMap<GarmentMeasurement, GarmentMeasurementModel>().ReverseMap();
                x.CreateMap<GarmentType, GarmentTypeModel>().ReverseMap();
                x.CreateMap<MeasurementType, MeasurementTypeModel>().ReverseMap();
            });
	    }

		private static void ConfigureDepenencies(IServiceCollection services)
		{
			services.AddScoped<CostumesBusiness>();
			services.AddScoped<MeasurementTypesBusiness>();
			
		}

    }
}

using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using PageantManager.Core.Entities;
using PageantManager.Core.Interfaces;
using PageantManager.Core.Models;
using PageantManager.Core.Services;
using PageantManager.Infrastructure.Data;

namespace PageantManager.Infrastructure.Utilities
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
	            x.CreateMap<GarmentMeasurementType, GarmentMeasurementTypeModel>().ReverseMap();
                x.CreateMap<GarmentType, GarmentTypeModel>().ReverseMap();
                x.CreateMap<MeasurementType, MeasurementTypeModel>().ReverseMap();
            });
	    }

		private static void ConfigureDepenencies(IServiceCollection services)
		{
			services.AddScoped(typeof(IAsyncRepository<>), typeof(PageantManagerRepository<>));
			services.AddScoped<ICostumeRepository, CostumeRepository>();
			services.AddScoped<ICostumeService, CostumeService>();
			services.AddScoped<IAdapter, Adapter>();
			services.AddSingleton(Mapper.Configuration);
			services.AddScoped<IMapper>(s => new Mapper(s.GetRequiredService<IConfigurationProvider>(), s.GetService));
		}

    }
}

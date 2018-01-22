using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PageantManager.Business.Entities;
using PageantManager.Business.Utilities;

namespace PageantManager.Business.Test
{
    public class Fixture : IDisposable
    {
        public readonly IServiceProvider ServiceProvider;

        public Fixture()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets<Fixture>();

            IConfigurationRoot config = builder.Build();

            var services = new ServiceCollection();
            services.AddDbContext<PageantManagerContext>(options => options.UseInMemoryDatabase("pm"));
            Configuration.Configure(services);
            
            ServiceProvider = services.BuildServiceProvider();

            Setup();

        }

        /// <summary>
        /// Run to setup in memory database.
        /// </summary>
        private void Setup()
        {
            var ctx = ServiceProvider.GetService<PageantManagerContext>();

            ctx.MeasurementTypes.Add(new MeasurementType{Name = "Head"});
            ctx.MeasurementTypes.Add(new MeasurementType{Name = "Chest"});
            ctx.MeasurementTypes.Add(new MeasurementType{Name = "Waist"});
            ctx.MeasurementTypes.Add(new MeasurementType{Name = "Hips"});
            ctx.MeasurementTypes.Add(new MeasurementType{Name = "Thigh"});
        }

        public void Dispose()
        {
            
        }
    }
}
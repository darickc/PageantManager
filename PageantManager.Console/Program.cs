using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PageantManager.Business.Entities;
using PageantManager.Business.Utilities;

namespace PageantManager.Console
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
                //.AddUserSecrets<Program>();

            IConfigurationRoot config = builder.Build();

            var services = new ServiceCollection();
            //services.AddDbContext<PageantManagerContext>(options => options.UseInMemoryDatabase("pm"));
            services.AddDbContext<PageantManagerContext>(options =>
                options.UseSqlite("Data Source=../PageantManager.Web/PageanManager.db"));
            Configuration.Configure(services);
            services.AddScoped<DataImport>();
            
            ServiceProvider provider = services.BuildServiceProvider();
            
            
            var dataImport = provider.GetService<DataImport>();
            await dataImport.Import();
        }
    }
}
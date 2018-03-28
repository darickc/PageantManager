using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PageantManager.Infrastructure.Data;
using PageantManager.Infrastructure.Utilities;

namespace PageantManager.Infrastructure.Test
{
    public class TestFixture : IDisposable
    {
        public readonly IServiceProvider ServiceProvider;

        public TestFixture()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddUserSecrets<TestFixture>();

            IConfigurationRoot config = builder.Build();

            var services = new ServiceCollection();
            //services.AddDbContext<PageantManagerContext>(options => options.UseInMemoryDatabase("pm"));
            services.AddDbContext<PageantManagerContext>(options =>
                options.UseSqlite("Data Source=../PageantManager.Web/PageanManager.db", b => b.MigrationsAssembly("PageantManager.Web")));
            Configuration.Configure(services);
            
            ServiceProvider = services.BuildServiceProvider();

            //Setup();

        }
        
        public void Dispose()
        {
        }
    }
}
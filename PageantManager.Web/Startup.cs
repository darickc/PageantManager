using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PageantManager.Business.Business;
using PageantManager.Business.Entities;

namespace PageantManager.Web
{
  public class Startup
  {
    private readonly IHostingEnvironment _env;
    readonly string _contentRootPath;
    public IConfigurationRoot Configuration { get; }

    public Startup(IHostingEnvironment env)
    {
      _env = env;
      var builder = new ConfigurationBuilder()
        .SetBasePath(env.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
        .AddEnvironmentVariables();
      if (env.IsDevelopment())
      {
        builder.AddUserSecrets<Startup>();
      }

      Configuration = builder.Build();
      _contentRootPath = env.ContentRootPath;
    }


    // This method gets called by the runtime. Use this method to add services to the container.
    // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddOptions();

      if (!_env.IsDevelopment())
      {
        services.Configure<MvcOptions>(options => { options.Filters.Add(new RequireHttpsAttribute()); });
      }
      else
      {
        services.AddCors();
      }

      services.AddMvc().AddJsonOptions(options =>
      {
        options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        options.SerializerSettings.Converters.Add(new Newtonsoft.Json.Converters.StringEnumConverter());
        options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
      });

      services.AddDbContext<PageantManagerContext>(options =>
        options.UseSqlite("Data Source=PageanManager.db", b => b.MigrationsAssembly("PageantManager.Web")));

      services.AddScoped<CostumesBusiness>();
      services.AddScoped<PageantsBusiness>();
      services.AddScoped<PerformancesBusiness>();

      Business.Utilities.Configuration.Configure();

    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
    {
      loggerFactory.AddConsole(Configuration.GetSection("Logging"));

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseBrowserLink();
        loggerFactory.AddDebug();
      }
      else if (env.IsStaging())
      {
        app.UseDeveloperExceptionPage();
        var options = new RewriteOptions().AddRedirectToHttps();
      }
      else
      {
        var options = new RewriteOptions().AddRedirectToHttps();
        //app.UseExceptionHandler("/Support/Error");
      }

      app.UseStaticFiles();

      app.UseMvc(routes =>
      {
        // uncomment for non angular SPA app, comment out code below
        //routes.MapRoute(
        //    name: "default",
        //    template: "{controller=Home}/{action=Index}/{id?}");

        // Comment out for non angular SPA app
        routes.MapRoute(
          "CatchAll",
          "{*url}",
          new {controller = "Home", action = "Index"}
        );
      });
    }
  }
}

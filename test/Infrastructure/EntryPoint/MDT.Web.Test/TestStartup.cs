using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MDT.Model.Gateway;
using MDT.UseCase;
using MDT.MongoDb.Entities;
using System;
namespace MDT.Web.Test
{
    public class TestStartup
    {
        private readonly string MyAllowSpecificOrigins = "AllowOrigin";
        public TestStartup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            EnvironmentLocal = environment;
        }
        public IHostingEnvironment EnvironmentLocal { get; }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var appSettings =  Configuration.GetSection("AppSettings").Get<TPMenuAppSetings>();
            /*
            var appSettings = new
            {
                TPMenuDatabaseString = "mongodb://127.0.0.1:27017",
                DatabaseMenu = "mdt"
            };
            */
            var mongoKey = appSettings.TPMenuDatabaseString;
            var mongoConn = mongoKey;
            Console.Out.WriteLine(mongoKey + " ... " + appSettings.DatabaseMenu);
            services.AddScoped<IEmpleadoRepository>(provider =>
             new EmpleadoAdapter(mongoConn, $"{appSettings.DatabaseMenu}")
            );

            services.BuildServiceProvider().GetService<IEmpleadoRepository>();

            var servicesProvider = services.BuildServiceProvider();

            services.AddTransient<HomeUseCase>(
                provider => new HomeUseCase(servicesProvider.GetRequiredService<IEmpleadoRepository>())
            );

            services.AddCors(options =>
            {
                options.AddPolicy(MyAllowSpecificOrigins,
                builder =>
                {
                    builder.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
                });
            });

            services.AddTransient<HomeController>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDataProtection();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMvcCore().AddApiExplorer();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins);
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseMvc();
        }
    }
}

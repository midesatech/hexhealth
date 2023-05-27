using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MDT.Model.Gateway;
using MDT.UseCase.Goals;
using MDT.MongoDb.Entities;
using System;
using MDT.AppService;
using MDT.SupabaseDb.Entities;

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
            var mongoKey = appSettings.TPMenuDatabaseString;
            var mongoConn = mongoKey;
            Console.Out.WriteLine(mongoKey + " ... " + appSettings.DatabaseMenu);

            var supabaseSettings = Configuration.GetSection("SupabaseSettings").Get<SupabaseSettings>();
            var supaApiKey = supabaseSettings.ApiKey;
            var supaUrl = supabaseSettings.Url;

            services.AddSingleton(provider => new Supabase.Client(supaUrl, supaApiKey));
            services.AddSingleton<IGoalRepository, GoalAdapter>();
            services.AddScoped<IEmpleadoRepository>(provider =>
             new EmpleadoAdapter(mongoConn, $"{appSettings.DatabaseMenu}")
            );

            services.BuildServiceProvider().GetService<IGoalRepository>();

            var servicesProvider = services.BuildServiceProvider();

            services.AddTransient<GoalUseCase>(
                provider => new GoalUseCase(servicesProvider.GetRequiredService<IGoalRepository>())
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

            services.AddTransient<GoalController>();
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDataProtection();
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
            
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MDT.Model.Data;
using MDT.Model.Gateway;
using MDT.MongoDb.Entities;
using MDT.UseCase;
using System;

namespace MDT.AppService
{
    public class Startup
    {
        private readonly string MyAllowSpecificOrigins = "AllowOrigin";


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var appSettings = Configuration.GetSection("AppSettings").Get<TPMenuAppSetings>();
            var mongoKey = appSettings.TPMenuDatabaseString;
            var mongoConn = mongoKey;
            Console.Out.WriteLine(mongoKey + "|"+appSettings.DatabaseMenu);

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<IEmpleadoRepository>(provider =>
             new EmpleadoAdapter(mongoConn, $"{appSettings.DatabaseMenu}")
            );

            services.BuildServiceProvider().GetService<IEmpleadoRepository>();
            services.AddTransient<HomeUseCase>();

            var servicesProvider = services.BuildServiceProvider();

            services.AddTransient<HomeUseCase>(provider => new HomeUseCase(servicesProvider.GetRequiredService<IEmpleadoRepository>()));

            HomeUseCase homeUseCase = services.BuildServiceProvider().GetService<HomeUseCase>();

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

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            
            services.AddMvcCore().AddApiExplorer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(MyAllowSpecificOrigins);
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            
        }
    }
}

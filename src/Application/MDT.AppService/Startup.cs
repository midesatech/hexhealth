using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MDT.Model.Gateway;
using MDT.SupabaseDb.Entities;
using MDT.UseCase.Goals;
using MDT.UseCase.Progress;
using MDT.UseCase.Awards;

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

            var supabaseSettings = Configuration.GetSection("SupabaseSettings").Get<SupabaseSettings>();
            var supaApiKey = supabaseSettings.ApiKey;
            var supaUrl = supabaseSettings.Url;

            services.AddSingleton(provider => new Supabase.Client(supaUrl, supaApiKey));

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            
            services.AddSingleton<IGoalRepository, GoalAdapter>();
            services.AddSingleton<IProgressRepository, ProgressAdapter>();
            services.AddSingleton<IAwardRepository, AwardAdapter>();

            var servicesProvider = services.BuildServiceProvider();

            services.AddTransient<IGoalUseCase>(provider => new GoalUseCase(servicesProvider.GetRequiredService<IGoalRepository>(), 
               servicesProvider.GetRequiredService<IProgressRepository>(),
               servicesProvider.GetRequiredService<IAwardRepository>()));
            services.AddTransient<IProgressUseCase>(provider => new ProgressUseCase(servicesProvider.GetRequiredService<IProgressRepository>()));
            services.AddTransient<IAwardUseCase>(provider => new AwardUseCase(servicesProvider.GetRequiredService<IAwardRepository>()));

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
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            //}
            //else
            //{
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            //}

            app.UseCors(MyAllowSpecificOrigins);
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            
        }
    }
}

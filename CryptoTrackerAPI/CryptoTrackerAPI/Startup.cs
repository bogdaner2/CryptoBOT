using AutoMapper;
using CryptoTrackerAPI.BLL.Profiles;
using CryptoTrackerAPI.DAL;
using CryptoTrackerAPI.DAL.Data;
using CryptoTrackerAPI.DAL.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CryptoTrackerAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            ConfigureAutoMapper(services);
            services.AddDbContext<CryptoTrackerDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly("CryptoTrackerAPI.DAL")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        private IServiceCollection ConfigureAutoMapper(IServiceCollection services)
        {
            //TODO: ADD PROFILES
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MarketProfile>();
                cfg.AddProfile<CryptoProfile>();
                cfg.AddProfile<SubscriptionProfile>();
            });

            return services;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}

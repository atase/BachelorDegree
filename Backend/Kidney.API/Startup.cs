
using AutoMapper;
using Business.Mapping;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Kidney.Business.Services;
using Kidney.DataAccess.DataContexts;
using Kidney.DataAccess.Interfaces;
using Kidney.Infrastructure.Repositories;
using Kidney.Infrastructure.Repositories.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace Transplant.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DataMapper));
            services.AddCors(o => o.AddDefaultPolicy(builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
            }));


            services.AddControllers();
            services.AddDbContext<ApplicationContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("KidneyTransplant")));


            services.AddTransient<IGiverRepository, GiverRepository>();
            services.AddTransient<IGiverService, GiverService>();

            services.AddTransient<IReceiverRepository, ReceiverRepository>();
            services.AddTransient<IReceiverService, ReceiverService>();

            services.AddTransient<ICompatibilityService, CompatibilityService>();
            services.AddTransient<IMatchingService, MatchingService>();

            services.AddTransient<IPrimaryDiagnosisRepository, PrimaryDiagnosisRepository>();
            services.AddTransient<IRaceRepository, RaceRepository>();

            services.AddTransient<ICompatibilityScoreRepository, CompatibilityScoreRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

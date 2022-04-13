using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SupportManagement.Api.Extensions;
using SupportManagement.Business.Abstract;
using SupportManagement.Business.Concrete;
using SupportManagement.DataAccess.Abstract;
using SupportManagement.DataAccess.Concrete;
using SupportManagement.DataAccess.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportManagement.Api
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
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SupportManagement.Api", Version = "v1" });
            });

            services.AddDbContext<ApplicationDbContext>();

            services.AddScoped<ITeamDal, TeamDal>();
            services.AddScoped<IChatDal, ChatDal>();

            services.AddScoped<ITeamService, TeamService>();
            services.AddScoped<IChatService, ChatService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ApplicationDbContext db)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "SupportManagement.Api v1"));
            }

            db.Database.EnsureCreated();

            app.UseRouting();

            app.UseAuthorization();

            app.UseExceptionMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

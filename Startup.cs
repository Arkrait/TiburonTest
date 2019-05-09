using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TiburonTest.Domain.Repositories;
using TiburonTest.Domain.Services;
using TiburonTest.Persistence.Contexts;
using TiburonTest.Persistence.Repositories;
using TiburonTest.Services;

namespace TiburonTest
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
            var pass = Environment.GetEnvironmentVariable("DB_PASS");
            var builder = new SqlConnectionStringBuilder
            {
                DataSource = "localhost", UserID = "sa", Password = pass, InitialCatalog = "master"
            };

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSpaStaticFiles(configuration => { configuration.RootPath = "spa/build"; });

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(builder.ConnectionString);
            });

            services.AddScoped<ISurveyUserRepository, SurveyUserRepository>();
            services.AddScoped<ISurveyUserService, SurveyUserService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddAutoMapper();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes => { routes.MapRoute(name: "default", template: "{controller}/{action=Index}/{id?}"); });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "spa";
                if (env.IsDevelopment())
                {
                    spa.UseProxyToSpaDevelopmentServer("http://localhost:3000");
                }
            });

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessCsvProvider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Model;

namespace Assecor
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
            var builder = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot config = builder.Build();

            var DatabaseType = config.GetConnectionString("DatabaseType");
            var sqlConnectionString = Configuration.GetConnectionString("DataAccessMsSqlServerProvider");
            
            switch (DatabaseType)
            {
                case "SqlServer":
                    //Use a MS SQL Server database
                    sqlConnectionString = Configuration.GetConnectionString("DataAccessMsSqlServerProvider");
                    services.AddHttpContextAccessor();
                    break;
            }
            
            services.AddDbContext<DomainModelCsvContext>();
            services.AddScoped<IDataAccessProvider, DaCsvProvider>();
            services.AddMvcCore().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

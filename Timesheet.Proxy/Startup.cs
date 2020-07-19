using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Timesheet.Proxy.Services;
using Timesheet.Proxy.Services.Interfaces;
using Timesheet.Proxy.Configuration;
using Timesheet.Proxy.Models;
using Microsoft.EntityFrameworkCore;

namespace Timesheet.Proxy
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddCors(option => 
            {
                option.AddPolicy(OriginKey.specificOriginKey, builder =>
                {
                    var origin = Configuration["TimesheetApplication:TimesheetOrigin"];
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowCredentials()
                           .WithOrigins(origin);
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_0).AddJsonOptions(options =>
            {
                var resolver = options.SerializerSettings.ContractResolver;
                if (resolver != null)
                {
                    (resolver as DefaultContractResolver).NamingStrategy = null;
                }
            });
            services.AddDbContext<TimesheetContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ApplicationConnection")));
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<ITimesheetService, TimesheetService>();
        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseCors(OriginKey.specificOriginKey);
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

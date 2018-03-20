using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EntityBlank.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;

namespace EntityBlank
{
    public class Startup
    {
        // NOTES: 
        // RUN THESE COMMANDS IN THE TERMINAL!!!!
        // dotnet add package Pomelo.EntityFrameworkCore.MySql -v 2.0.1
        // dotnet add package MySql.Data -v 8.0.9-*
        // DON'T FORGET TO RESTORE!!!!

        public IConfiguration Configuration { get; private set; }
        
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();
            Configuration = builder.Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSession();
            services.AddDbContext<YourContext>(options => options.UseMySql(Configuration["DBInfo:ConnectionString"]));
        }
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseSession();
            app.UseMvc();
        }
    }
}
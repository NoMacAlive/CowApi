using System;
using System.Net.Mime;
using CowApi.Controllers;
using CowApi.Repositories;
using CowApi.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;

namespace CowApi
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
            services
                .AddRefitClient<ICowAPI>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(Configuration["CowApiAddress"]));
            //configure postgresql
            services.AddDbContext<CowContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("CowContext")));
            //configure redis cache
            services.AddStackExchangeRedisCache( options =>
            {
                options.Configuration = Configuration.GetConnectionString( "Redis" );
            } );

            services.AddScoped<ICowRepository, CowRepository>( );
            services.AddScoped<ICollarStatusService, CollarStatusService>( );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler( options => options.Run(
                    async context =>
                    {
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = MediaTypeNames.Text.Plain;

                        await context.Response.WriteAsync("Something went wrong, please try again later or try with different data.");
                    }
                ) );
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

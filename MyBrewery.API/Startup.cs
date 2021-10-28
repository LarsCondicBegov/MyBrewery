using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MyBrewery.API.ApiModels.Requests.Recipes;
using MyBrewery.Application.Commands.Recipes;
using MyBrewery.Application.Repositories;
using MyBrewery.Domain.Repositories.Recipes;
using MyBrewery.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBrewery.API
{
    public class Startup
    {
        private IWebHostEnvironment Environment { get; }
        private IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Environment = env;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyBreweryDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddAutoMapper(GetType().Assembly);

            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateRecipeRequestValidator>());

            services.AddScoped<IRecipeRepository, RecipeRepository>();
           
            services.AddMediatR(typeof(CreateRecipeCommand).Assembly);

            services.AddSignalR();

            // Configure CORS
            services.AddCors(corsOptions => corsOptions.AddPolicy(
                "Default",
                corsPolicyBuilder => corsPolicyBuilder
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithExposedHeaders("errorhandling")
                    .SetIsOriginAllowed((host) => true)
                    .AllowCredentials()));

            // Register Controllers
            services.AddControllers();

            // Register Swagger
            services.AddOpenApiDocument(document =>
            {
                document.PostProcess = d =>
                {
                    d.Info.Version = "v1";
                    d.Info.Title = "MyBrewery API";
                    d.Info.Description = "An API for Brewing recipes";
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            // Enable authentication middleware
            app.UseAuthentication();
            //app.UseProblemDetails(); // Convert unhandled exceptions to RFC 7807

            if (!env.IsDevelopment())
            {
                app.UseHsts();
            }
            else
                app.UseDeveloperExceptionPage();

            // Add OpenAPI/Swagger middleware
            app.UseOpenApi(); // Serves the registered OpenAPI/Swagger documents by default on `/swagger/{documentName}/swagger.json`
            app.UseSwaggerUi3(settings => // Serves the Swagger UI 3 web ui to view the OpenAPI/Swagger documents by default on `/swagger`
            {
                settings.TransformToExternalPath = (internalUiRoute, request) =>
                {
                    // See: https://github.com/RSuter/NSwag/issues/1934 & https://github.com/RSuter/NSwag/wiki/AspNetCore-Middleware#hosting-as-an-iis-virtual-application

                    if (internalUiRoute.StartsWith("/") && internalUiRoute.StartsWith(request.PathBase) == false)
                    {
                        return request.PathBase + internalUiRoute;
                    }

                    return internalUiRoute;
                };


                settings.DocExpansion = "list";

                settings.DefaultModelsExpandDepth = 0;
            });

            // Enable CORS
            app.UseCors("Default");
            app.UseHttpsRedirection();

            // EXECUTION ORDER IS IMPORTANT for next 3 calls

            // 1)
            app.UseRouting();

            // 2)
            app.UseAuthorization();

            // 3) Configure endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

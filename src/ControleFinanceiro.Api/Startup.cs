using ControleFinanceiro.Api.Extensions;
using ControleFinanceiro.Service.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json;

namespace ControleFinanceiro.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(
            IConfiguration configuration,
            IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServices();

            services.AddControllers(c => c.Conventions.Add(new ApiExplorerGroupPerVersionConvention()))
                .AddDataAnnotationsLocalization()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
                    options.JsonSerializerOptions.WriteIndented = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                });

            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(x => x.Name);

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "API Projeto Base - Api Template", //TODO: Modificar nome
                        Version = "v1",
                        Description = "API de Integracao para cadastrar favoritos transacionais",
                        //Contact = new OpenApiContact
                        //{
                        //    Name = "Manual de Desenvolvimento",
                        //    Url = new Uri("")
                        //},
                        //TermsOfService = new Uri(""),
                        //License = new OpenApiLicense
                        //{
                        //    Name = "Projeto Base",
                        //    Url = new Uri(""),
                        //}
                    });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            var env = Configuration.GetValue<string>("ENVIRONMENT");

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app, ILogger<Startup> logger)
        {
            //// Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger(c =>
            {
                c.RouteTemplate = "swagger/{documentName}/swagger.json";
                c.SerializeAsV2 = true;
            });

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.)
            app.UseSwaggerUI();

            app.UseHsts();

            app.UseHealthChecks("/health")
                .UseSwagger()
                .UseStaticFiles()
                .UseHttpsRedirection();

            app.UseRouting()
                .UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}

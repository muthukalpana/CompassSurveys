using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CompassSurveys.Filters;
using CompassSurveys.Models;
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

namespace CompassSurveys
{

    /// <summary>  
    /// Startup class.  
    /// </summary>  

    public class Startup
    {

        /// <summary>  
        /// Initializes a new instance of the <see cref="Startup" /> class.  
        /// </summary> 
        /// <param name="configuration">configuration.</param> 

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>  
        /// Configuration.  
        /// </summary> 

        public IConfiguration Configuration { get; }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        /// <summary>  
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary> 
        /// <param name="services">configuration.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("http://localhost:3000");
                                  });
            });
            services.AddDbContext<CompassSurveysContext>(options => options.UseSqlite("DataSource=" + Directory.GetCurrentDirectory() + "\\" + Configuration.GetConnectionString("SurveysDatabase")));
            services.AddScoped<IDatabaseManager, DatabaseManager>();
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(InformationLogger));
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Compass Surveys API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });
            services.AddControllers();
        }

        /// <summary>  
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary> 
        /// <param name="app">configuration.</param>
        /// <param name="env">configuration.</param>
        /// <param name="loggerFactory">configuration.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            loggerFactory.AddFile(Directory.GetCurrentDirectory() + "\\Logs\\logs-{Date}.log");
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseCors(MyAllowSpecificOrigins);

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Compass Surveys API");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

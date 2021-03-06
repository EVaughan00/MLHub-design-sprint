using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BuildingBlocks.Utils.Exceptions;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using System.IO;
using System;
using Models.API.Initializers;
using Application.Config;
using Models.Api.EventHandlers;
using BuildingBlocks.Common.Events;
using Models.Infrastructure.IntegrationEvents;
using BuildingBlocks.Common.Events.Bus;

namespace Models.API 
{
    public class Startup {

        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        public IServiceProvider ConfigureServices(IServiceCollection services) {

            services.InitializeAll(Configuration);
            services.AddLogging(logging => logging.AddConsole());
            services.Configure<MongoDBSettings>(Configuration.GetSection("MongoDB"));

            services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                    builder =>
                    {
                        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                    });
            });

            var container = new ContainerBuilder();
            
            container.Populate(services);
            container.RegisterModule(new RepositoryModule());
            container.RegisterModule(new MediatorModule());
            container.RegisterModule(new EventBusModule());

            return new AutofacServiceProvider(container.Build());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory logger) {
            
            var pathBase = Directory.GetCurrentDirectory();
            
            if (!string.IsNullOrEmpty(pathBase)){
                logger.CreateLogger<Startup>().LogDebug("Using PATH BASE '{pathBase}'", pathBase);
                app.UsePathBase(pathBase);
            }    
            
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseHsts();             
            }

            app.UseMiddleware(typeof(ErrorHandlingMiddleware));

            // app.UseHttpsRedirection();
            app.UseRouting();
            
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Models Service v1");
            });

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });

            // ConfigureEventBus(app);
        }

        
        private void ConfigureEventBus(IApplicationBuilder app)
        {
            var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
            eventBus.Subscribe<ModelsCreatedIntegrationEvent, ModelsCreatedIntegrationEventHandler>();
        }
    }
}

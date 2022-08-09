﻿using PowerServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ServerAPIs
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment hostingEnvironment)
        {
            this.Configuration = configuration;
            this.HostingEnvironment = hostingEnvironment;
        }
        
        // ASP.NET Core configuration, for getting the configuration data from different configuration sources (such as environment variables, commandline arguments)
        // see https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/
        public IConfiguration Configuration { get; }
        
        // ASP.NET Core hosting environment, for getting the root directory and startup environment of the application
        // see https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/generic-host#ihostenvironment
        public IHostEnvironment HostingEnvironment { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Configures the services of the PowerServer AppConfig module
            services.AddPowerServerAppConfig(this.Configuration, this.HostingEnvironment);
            
            // Configures the services of the PowerServer Authentication module 
            services.AddPowerServerAuthentication(this.Configuration);
            
            // Configures the services of the PowerServer HealthCheck module 
            services.AddPowerServersHealthChecks(this.Configuration);
            
            // Configures the services of the PowerServer Logging module 
            services.AddPowerServerLogging();
            
            // Configures the services of the PowerServer OpenAPI module
            services.AddPowerServerOpenAPI();
            
            services.AddPowerServerDataProvider(this.GetType().Assembly);
            
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                .AddInMemoryIdentityResources(Config.GetIdentityResources())
                .AddInMemoryApiResources(Config.GetApiResources())
                .AddInMemoryClients(Config.GetClients())
                .AddTestUsers(Config.GetUsers());
                
            services.AddControllersWithViews();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {

            app.UseCors(m =>
            {
                m.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
            });
            
            app.UsePowerServerPathBase();
            
            if (this.HostingEnvironment.IsDevelopment())
            {
                // Enables the exception page during development. It will list all exceptions for debugging
                app.UseDeveloperExceptionPage();
                
                // Configures the HTTP request pipeline for the PowerServer OpenAPI module
                app.UsePowerServerOpenAPI();
            }
            
            app.UseIdentityServer();
            app.UseStaticFiles();
            
            // Adds middleware for redirecting HTTP Requests to HTTPS.
            //app.UseHttpsRedirection();
            
            // Configures the HTTP request pipeline for the PowerServer Logging module
            app.UsePowerServerLogging();
            
            app.UseRouting();
            
            // Enables the compression of responses
            app.UseResponseCompression();
            
            // Enables authentication
            app.UseAuthentication();
            
            // Enables authorization
            app.UseAuthorization();
            
            // Enables the welcome page
            app.UseWelcomePage("/");
            
            // Configures the HTTP request pipeline for the PowerServer HealthCheck module
            app.UsePowerServerHealthChecks();
            
            app.UseEndpoints(endpoints =>
            {
                // Adds the controller to the HTTP request pipeline
                endpoints.MapControllers();
             });
        }
    }
}

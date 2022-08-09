using IdentityServer4.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ServerAPIs
{
    public static class AuthenticationExtensions
    {
        // To be called in Startup.ConfigureServices, for adding services related with the authentication module
        public static IServiceCollection AddPowerServerAuthentication(
            this IServiceCollection services, IConfiguration configuration)
        {
            
            services.AddSingleton<ICorsPolicyService>((container) =>
            {
                var logger = container.GetRequiredService<ILogger<DefaultCorsPolicyService>>();
                return new DefaultCorsPolicyService(logger)
                {
                    AllowAll = true
                    //AllowedOrigins = { "https://foo", "https://bar" }
                };
            });
            
            //The current template does not provide authentication service. If you want to use authentication service, change to another template
            return services;
        }
    }
}

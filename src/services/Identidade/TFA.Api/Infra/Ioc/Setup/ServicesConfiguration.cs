using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using TFA.Api.Infra.Ioc.Swagger;

namespace TFA.Api.Infra.Ioc.Setup
{
    public static class DependencesConfig
    {
        public static void ResolveDependencies(this IServiceCollection services)
        {
            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

        }
    }
}

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Demo.Extensions
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder AddJsonFiles(this IConfigurationBuilder builder, IHostingEnvironment env)
        {
            builder.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);
            return builder;
        }
    }
}
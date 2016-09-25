using Microsoft.Extensions.DependencyInjection;

namespace Demo.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCustomizedMvc(this IServiceCollection services)
        {
            services.AddMvc()
               .AddRazorOptions(options =>
               {
               });

            return services;
        }

        public static IServiceCollection AddCustomizedMvcCors(this IServiceCollection services)
        {
            services.AddMvcCore(cors =>
            {
            });

            return services;
        }

        /// <summary>
        /// Use Redis Cache in Staging
        /// </summary>
        /// <param name="services"></param>
        //public void ConfigureStagingServices(IServiceCollection services)
        //{

        //    services.AddDistributed.AddDistributedRedisCache(options =>
        //    {
        //        options.Configuration = "localhost";
        //        options.InstanceName = "SampleInstance";
        //    });
        //}
    }
}
using System.Collections.Generic;
using System.Linq;
using Demo.Extensions;
using Demo.Views.TestLab.Repositories;
using Demo.Views.TestLab.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using NLog.Web;

namespace Demo
{
    public class Startup
    {
        //default supported Mime Types 
        public static readonly IEnumerable<string> MimeTypes = new[]
        {
            // General
            "text/plain",
            // Static files
            "text/css",
            "application/javascript",
            // MVC
            "text/html",
            "application/xml",
            "text/xml",
            "application/json",
            "text/json",
        };
        public IConfigurationRoot Configuration { get; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("launchSettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddJsonFiles(env)
                .AddEnvironmentVariables();
            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                //builder.AddUserSecrets();
            }
            Configuration = builder.Build();
        }

        // This method gets called by the runtime. 
        //Use this method to add services to the container.
        //Dependency Injection (DI) is not setup until after ConfigureServices is 
        //invoked and the configuration system is not DI aware.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                            {
                               "image/svg+xml",
                               "application/atom+xml"
                            });
                options.Providers.Add<GzipCompressionProvider>();
            });//Microsoft.AspNetCore.ResponseCompression
            services.AddResponseCaching();
            services.AddCustomizedMvc();
            services.AddCustomizedMvcCors();

            // Add application services.
            //services.AddTransient<IEmailSender, AuthMessageSender>();
            //services.AddTransient<ISmsSender, AuthMessageSender>();
            services.AddTransient<IUserRepository, UserRepository>();
        }

        public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            env.ConfigureNLog("nlog.config");
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseStaticFiles();
            app.UseResponseCompression(); //requires services.AddCustomizedMvcCors();
            app.UseResponseCaching();    //requires services.AddResponseCaching();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            env.ConfigureNLog("nlog.config");

            app.UseStaticFiles();
            app.UseResponseCompression(); //requires services.AddCustomizedMvcCors();
            app.UseResponseCaching();    //requires services.AddResponseCaching();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
using System;
using Lykke.AzureRepositories;
using Lykke.Common.Service.Dictionary.Code;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Lykke.Common.Service.Dictionary
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            BuildContainer(services);
            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();
        }


        private void BuildContainer(IServiceCollection services)
        {
            var connectionString = Configuration.GetValue<string>("ConnectionString");

#if DEBUG
            var generalSettings = SettingsReader.SettingsReader.ReadGeneralSettings<Settings>(connectionString);
#else
            var generalSettings = SettingsReader.SettingsReader.ReadGeneralSettings<Settings>(new Uri(connectionString));
#endif
            var settings = generalSettings.CommonServiceDictionary;

            services.AddSingleton(settings);
            services.RegisterRepositories(settings.Db.DictsConnString, null);
        }
    }
}

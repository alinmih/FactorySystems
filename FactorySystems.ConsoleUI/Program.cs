using FactorySystems.BLLibrary;
using FactorySystems.BLLibrary.CompanyData;
using FactorySystems.CommonLibrary.GlobalConfig;
using FactorySystems.DALibrary;
using FactorySystems.Root;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.IO;
using System.Threading.Tasks;

namespace FactorySystems.ConsoleUI
{
    class Program
    {
        public static IConfigurationRoot configuration;

        static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.Console(Serilog.Events.LogEventLevel.Debug).MinimumLevel.Debug().Enrich.FromLogContext().CreateLogger();

            try
            {
                //Start
                MainAsync(args).Wait();
                return 0;
            }
            catch (Exception)
            {

                return 1;
            }
        }

        private static async Task MainAsync(string[] args)
        {
            // Create service collection
            Log.Information("Creating service collection");
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider
            Log.Information("Building service provider");
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            // Print connection string to demonstrate configuration object is populated
            Console.WriteLine(configuration.GetConnectionString("Default"));

            try
            {
                Log.Information("Starting service");
                await serviceProvider.GetService<App>().Run();
                Log.Information("Ending service");
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Error running service");
                throw ex;
            }
            finally
            {
                Log.CloseAndFlush();
            }

        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(LoggerFactory.Create(builder =>
                {
                    builder.AddSerilog(dispose: true);
                }
            ));

            services.AddLogging();

            // Build configuration
            configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();


            services.AddSingleton<IConfigurationRoot>(configuration);
            CommonLibrary.GlobalConfig.GlobalConfig.ConnectionString = configuration.GetConnectionString("Default");

            services.AddTransient<App>();

            CompositionRoot.InjectServices(services);

        }



    }
}

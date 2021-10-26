using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Smokeball.Services;
using Smokeball.Utilities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Smokeball
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        public IConfiguration Configuration { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("AppSetting.json", optional: false, reloadOnChange: true);

            Configuration = builder.Build();

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            var urlFinder = ServiceProvider.GetRequiredService<UrlFinder>();
            urlFinder.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration.GetSection(nameof(AppSettings)));

            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient(typeof(UrlFinder));
            services.AddSingleton(typeof(Utils));

        }
    }
}

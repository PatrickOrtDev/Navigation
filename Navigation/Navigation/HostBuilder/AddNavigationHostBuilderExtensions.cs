using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Navigation.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Navigation.HostBuilder
{
    public static class AddNavigationHostBuilderExtensions
    {
        public static IHostBuilder AddNavigationViewModels(this IHostBuilder host, IEnumerable<KeyValuePair<IViewModel, NavigationType>> viewModels)
        {
            //host.ConfigureServices(services => 
            //{
            //    services.Add(new ServiceCollection());
            //});

            return host;
        }
    }

    public enum NavigationType
    {
        NavigateTo = 0,
        ShowModal = 1,
    }
}

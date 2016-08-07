using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.TestHost.Tests.Internal
{
    public static class MyContainerFactoryWebHostBuilderExtensions
    {
        public static IWebHostBuilder UseMyContainer(this IWebHostBuilder host)
        {
            return host.ConfigureServices(services =>
            {
                services.AddTransient<IServiceProviderFactory, MyContainerFactory>();
            });
        }
    }
}

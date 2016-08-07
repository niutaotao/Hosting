using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.TestHost.Tests.Internal
{
    public class MyContainerFactory : ServiceProviderFactory<MyContainer>
    {
        public override MyContainer CreateBuilder(IServiceCollection services)
        {
            var container = new MyContainer();
            container.Populate(services);
            return container;
        }

        public override IServiceProvider CreateServiceProvider(MyContainer containerBuilder)
        {
            containerBuilder.Build();
            return containerBuilder;
        }
    }

}

// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Hosting
{
    public abstract class StartupBase : IStartup
    {
        public abstract void Configure(IApplicationBuilder app);

        public virtual IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BuildServiceProvider();
        }
    }

    public abstract class StartupBase<TContainer> : IStartup
    {
        private readonly IServiceProviderFactory _factory;

        public StartupBase(IServiceProviderFactory factory)
        {
            _factory = factory;
        }

        public abstract void Configure(IApplicationBuilder app);

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var builder = _factory.CreateBuilder(services);
            ConfigureContainer((TContainer)builder);
            return _factory.CreateServiceProvider(builder);
        }

        public virtual void ConfigureContainer(TContainer builder) { }
    }
}
// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Microsoft.AspNetCore.Hosting.Internal
{
    public class StartupMethods
    {
        public StartupMethods(Action<IApplicationBuilder> configure, Func<IServiceCollection, IServiceProvider> configureServices)
        {
            ConfigureDelegate = configure;
            ConfigureServicesDelegate = configureServices;
        }

        public Func<IServiceCollection, IServiceProvider> ConfigureServicesDelegate { get; }
        public Action<IApplicationBuilder> ConfigureDelegate { get; }

    }
}
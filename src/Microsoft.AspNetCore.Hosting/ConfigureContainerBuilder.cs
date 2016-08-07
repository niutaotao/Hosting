using System;
using System.Linq;
using System.Reflection;

namespace Microsoft.AspNetCore.Hosting.Internal
{
    public class ConfigureContainerBuilder
    {
        public ConfigureContainerBuilder(MethodInfo configureContainerMethod)
        {
            MethodInfo = configureContainerMethod;
        }

        public MethodInfo MethodInfo { get; }

        public Action<object> Build(object instance) => container => Invoke(instance, container);

        private void Invoke(object instance, object container)
        {
            if (MethodInfo == null)
            {
                return;
            }

            // Only support IServiceCollection parameters
            var parameters = MethodInfo.GetParameters();
            if (parameters.Length != 1 ||
                parameters.Any(p => !p.ParameterType.IsAssignableFrom(container.GetType())))
            {
                throw new InvalidOperationException($"The {MethodInfo.Name} method must either be parameterless or take only one parameter of type {container.GetType()}.");
            }

            var arguments = new object[MethodInfo.GetParameters().Length];

            // Ctor ensures we have at most one IServiceCollection parameter
            if (parameters.Length > 0)
            {
                arguments[0] = container;
            }

            MethodInfo.Invoke(instance, arguments);
        }
    }
}
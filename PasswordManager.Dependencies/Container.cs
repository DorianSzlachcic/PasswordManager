using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.Dependencies
{
    public static class Container
    {
        public static IContainer Instance { get; private set; }

        public static void BuildContainer(Action<ContainerBuilder> buildAction)
        {
            if (Instance != null)
                return;

            var containerBuilder = new ContainerBuilder();
            buildAction(containerBuilder);
            Instance = containerBuilder.Build();
        }
    }
}

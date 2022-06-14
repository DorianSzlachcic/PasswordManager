using Autofac;
using PasswordManager.BusinessLogic.Services.Database;
using PasswordManager.BusinessLogic.Services.File;
using PasswordManager.BusinessLogic.Services.Password;
using PasswordManager.BusinessLogic.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BusinessLogic.Dependencies
{
    public static class Configuration
    {
        public static void Configure(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<GeneratorService>().As<IGeneratorService>().SingleInstance();
            containerBuilder.RegisterType<SecurityService>().As<ISecurityService>().SingleInstance();
            containerBuilder.RegisterType<JsonService>().As<IJsonService>().SingleInstance();
            containerBuilder.RegisterType<SqliteAccountService>().As<ISqliteAccountService>().SingleInstance();
            containerBuilder.RegisterType<SqliteGroupService>().As<ISqliteGroupService>().SingleInstance();


            containerBuilder.RegisterType<MainWindowViewModel>();
            containerBuilder.RegisterType<StartViewModel>();
            containerBuilder.RegisterType<AccountsViewModel>();
            containerBuilder.RegisterType<AddEditViewModel>();
        }
    }
}

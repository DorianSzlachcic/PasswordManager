using Spooksoft.VisualStateManager.Commands;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PasswordManager.Dependencies;
using PasswordManager.BusinessLogic.Services.File;
using PasswordManager.BusinessLogic.Services.Password;

namespace PasswordManager.BusinessLogic.ViewModels.Main
{
    public class MainWindowViewModel : BaseViewModel, IChangeScreenHandler
    {
        private BaseScreenViewModel currentScreen;
        private ICommand changeToStartViewCommand;
        private ICommand changeToAccountsViewCommand;

        public MainWindowViewModel()
        {
            CurrentScreen = Container.Instance.Resolve<StartViewModel>(new NamedParameter("handler", this));
            ChangeToAccountsViewCommand = new AppCommand(obj => CurrentScreen = Container.Instance.Resolve<AccountsViewModel>(new NamedParameter("handler", this)));
            ChangeToStartViewCommand = new AppCommand(obj => CurrentScreen = Container.Instance.Resolve<StartViewModel>(new NamedParameter("handler", this)));
        }

        //Public Variables
        public BaseScreenViewModel CurrentScreen
        {
            get => currentScreen;
            set => Set(ref currentScreen, value);
        }

        public ICommand ChangeToStartViewCommand
        {
            get => changeToStartViewCommand;
            set => Set(ref changeToStartViewCommand, value);
        }
        public ICommand ChangeToAccountsViewCommand
        {
            get => changeToAccountsViewCommand;
            set => Set(ref changeToAccountsViewCommand, value);
        }

        //IChangeScreenHandler implementation
        void IChangeScreenHandler.ChangeScreenToStartView()
        {
            CurrentScreen = Container.Instance.Resolve<StartViewModel>(new NamedParameter("handler", this));
        }
        void IChangeScreenHandler.ChangeScreenToAddView()
        {
            CurrentScreen = Container.Instance.Resolve<AddViewModel>(new NamedParameter("handler", this));
        }
        void IChangeScreenHandler.ChangeScreenToAccountsView()
        {
            CurrentScreen = Container.Instance.Resolve<AccountsViewModel>(new NamedParameter("handler", this));
        }
    }
}

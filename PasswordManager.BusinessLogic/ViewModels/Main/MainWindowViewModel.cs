using Spooksoft.VisualStateManager.Commands;
using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PasswordManager.Dependencies;

namespace PasswordManager.BusinessLogic.ViewModels.Main
{
    public class MainWindowViewModel : BaseViewModel, IChangeScreenHandler
    {
        private BaseScreenViewModel currentScreen;
        private ICommand changeToStartViewCommand;
        private ICommand changeToAccountsViewCommand;
        private ICommand addGroupCommand;

        public MainWindowViewModel()
        {
            CurrentScreen = Container.Instance.Resolve<StartViewModel>(new NamedParameter("handler", this));
            ChangeToAccountsViewCommand = new AppCommand(obj => CurrentScreen = Container.Instance.Resolve<AccountsViewModel>(new NamedParameter("handler", this)));
            ChangeToStartViewCommand = new AppCommand(obj => CurrentScreen = Container.Instance.Resolve<StartViewModel>(new NamedParameter("handler", this)));
            AddGroupCommand = new AppCommand(obj => { });
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
        public ICommand AddGroupCommand
        {
            get => addGroupCommand;
            set => Set(ref addGroupCommand, value);
        }

        //IChangeScreenHandler implementation
        void IChangeScreenHandler.ChangeScreenToStartView()
        {
            CurrentScreen = Container.Instance.Resolve<StartViewModel>(new NamedParameter("handler", this));
        }
        void IChangeScreenHandler.ChangeScreenToAddEditView()
        {
            CurrentScreen = Container.Instance.Resolve<AddEditViewModel>(new NamedParameter("handler", this));
        }
        void IChangeScreenHandler.ChangeScreenToAddEditView(int id)
        {
            CurrentScreen = Container.Instance.Resolve<AddEditViewModel>(new NamedParameter("handler", this), new NamedParameter("accountID", id));
        }
        void IChangeScreenHandler.ChangeScreenToAccountsView()
        {
            CurrentScreen = Container.Instance.Resolve<AccountsViewModel>(new NamedParameter("handler", this));
        }
    }
}

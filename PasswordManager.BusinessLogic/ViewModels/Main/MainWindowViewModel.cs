using Spooksoft.VisualStateManager.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PasswordManager.BusinessLogic.ViewModels.Main
{
    public class MainWindowViewModel : BaseViewModel, IChangeScreenHandler
    {
        private BaseScreenViewModel currentScreen;
        private ICommand changeToStartViewCommand;
        private ICommand changeToAccountsViewCommand;

        public MainWindowViewModel()
        {
            CurrentScreen = new StartViewModel(this);
            ChangeToAccountsViewCommand = new AppCommand(obj => CurrentScreen = new AccountsViewModel(this));
            ChangeToStartViewCommand = new AppCommand(obj => CurrentScreen = new StartViewModel(this));
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
            CurrentScreen = new StartViewModel(this);
        }
        void IChangeScreenHandler.ChangeScreenToAddView()
        {
            CurrentScreen = new AddViewModel(this);
        }
        void IChangeScreenHandler.ChangeScreenToAccountsView()
        {
            CurrentScreen = new AccountsViewModel(this);
        }
    }
}

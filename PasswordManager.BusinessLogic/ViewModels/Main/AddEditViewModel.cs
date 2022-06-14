using PasswordManager.BusinessLogic.Services.File;
using PasswordManager.BusinessLogic.Models;
using PasswordManager.BusinessLogic.Services.Password;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.BusinessLogic.Services.Database;
using System.Windows.Input;
using Spooksoft.VisualStateManager.Commands;

namespace PasswordManager.BusinessLogic.ViewModels.Main
{
    public class AddEditViewModel : BaseScreenViewModel
    {
        private int? id;
        private string? name;
        private string? login;
        private string? password;

        private ICommand confirmCommand;
        private ICommand cancelCommand;

        private ISqliteAccountService sqliteService;
        private ISecurityService securityService;

        public AddEditViewModel(IChangeScreenHandler handler, ISqliteAccountService sqliteService, ISecurityService securityService, int? accountID = null):base(handler)
        {
            this.sqliteService = sqliteService;
            this.securityService = securityService;

            CancelCommand = new AppCommand(obj => handler.ChangeScreenToStartView());

            if(accountID != null)
            {
                this.id = accountID;
                var account = sqliteService.GetAccountByID((int)id);
                if(account != null)
                {
                    Name = account.Name;
                    Login = account.Login;
                    Password = securityService.DecryptAES(account.Password);
                }
                ConfirmCommand = new AppCommand(obj => editAccount());
            }
            else
                ConfirmCommand = new AppCommand(obj => addAccount());
        }
        private void addAccount()
        {
            if ((Name != "" && Name != null) && (Login != "" && Login != null)
                && (Password != "" && Password != null))
            {
                sqliteService.SaveAccount(new Account(Name, Login, securityService.EncryptAES(Password)));
                changeScreenHandler.ChangeScreenToAccountsView();
            }
        }

        private void editAccount()
        {
            if ((Name != "" && Name != null) && (Login != "" && Login != null)
                && (Password != "" && Password != null))
            {
                sqliteService.UpdateAccount(new Account(Name, Login, securityService.EncryptAES(Password), id));
                changeScreenHandler.ChangeScreenToAccountsView();
            }
        }

        //Public Variables
        public string? Name
        {
            get => name;
            set => Set(ref name, value);
        }
        public string? Login
        {
            get => login;
            set => Set(ref login, value);
        }
        public string? Password
        {
            get => password;
            set => Set(ref password, value);
        }

        public ICommand ConfirmCommand
        {
            get => confirmCommand;
            set => Set(ref confirmCommand, value);
        }

        public ICommand CancelCommand
        {
            get => cancelCommand;
            set => Set(ref cancelCommand, value);
        }
    }
}

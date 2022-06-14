using PasswordManager.BusinessLogic.Services.File;
using PasswordManager.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.BusinessLogic.Services.Database;
using System.Windows.Input;
using Spooksoft.VisualStateManager.Commands;
using System.Diagnostics;

namespace PasswordManager.BusinessLogic.ViewModels.Main
{
    public class AccountsViewModel : BaseScreenViewModel
    {
        private ISqliteAccountService sqliteService;
        private List<Account>? accounts;

        private ICommand editCommand;
        private ICommand deleteCommand;

        public AccountsViewModel(IChangeScreenHandler handler, ISqliteAccountService sqliteService) : base(handler)
        {
            this.sqliteService = sqliteService;
            Accounts = sqliteService.LoadAccounts();

            EditCommand = new AppCommand(obj => handler.ChangeScreenToAddEditView((int)obj));

            DeleteCommand = new AppCommand(obj => { 
                sqliteService.DeleteAccount((int)obj);
                Accounts.RemoveAll(acc => { return acc.ID == (int)obj; });
                });
        }

        public List<Account>? Accounts {
            get => accounts;
            set => Set(ref accounts, value);
        }
        public ICommand EditCommand
        {
            get => editCommand;
            set => Set(ref editCommand, value);
        }
        public ICommand DeleteCommand
        {
            get => deleteCommand;
            set => Set(ref deleteCommand, value);
        }
    }
}

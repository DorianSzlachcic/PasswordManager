using PasswordManager.BusinessLogic.Services.File;
using PasswordManager.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordManager.BusinessLogic.Services.Database;

namespace PasswordManager.BusinessLogic.ViewModels.Main
{
    public class AccountsViewModel : BaseScreenViewModel
    {
        private ISqliteService sqliteService;
        private List<Account>? accounts;
        public AccountsViewModel(IChangeScreenHandler handler, ISqliteService sqliteService) : base(handler)
        {
            this.sqliteService = sqliteService;
            Accounts = sqliteService.LoadAccounts();
        }

        public List<Account>? Accounts {
            get => accounts;
            set => Set(ref accounts, value);    
        }
    }
}

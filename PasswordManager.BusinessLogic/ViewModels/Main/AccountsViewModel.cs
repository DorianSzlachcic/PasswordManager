using PasswordManager.BusinessLogic.Services.File;
using PasswordManager.BusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BusinessLogic.ViewModels.Main
{
    public class AccountsViewModel : BaseScreenViewModel
    {
        private JsonService jsonService;
        private List<Account>? accounts;
        public AccountsViewModel(IChangeScreenHandler handler) : base(handler)
        {
            jsonService = new JsonService("accounts.json");
            Accounts = jsonService.LoadFromFile();
        }

        public List<Account>? Accounts {
            get => accounts;
            set => Set(ref accounts, value);    
        }
    }
}

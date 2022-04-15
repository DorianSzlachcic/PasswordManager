using PasswordManager.BusinessLogic.Services.File;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BusinessLogic.ViewModels.Main
{
    public class AccountsViewModel :INotifyPropertyChanged
    {
        private JsonService jsonService;
        private List<Account>? accounts;
        public AccountsViewModel()
        {
            jsonService = new JsonService("accounts.json");
            Accounts = jsonService.LoadFromFile();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public List<Account>? Accounts { 
            get { return accounts; }
            set 
            {
                accounts = value;
                OnPropertyChanged(nameof(Accounts));
            } }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using PasswordManager.BusinessLogic.Services.File;
using PasswordManager.BusinessLogic.Services.Password;

namespace PasswordManager.BusinessLogic.ViewModels.Main
{
    public class StartViewModel :INotifyPropertyChanged
    {
        private List<Account>? accountsList;
        private string? generatedPassword;

        private JsonService jsonService;

        private void updateAccounts()
        {
            Accounts = jsonService.LoadFromFile();
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public StartViewModel()
        {
            jsonService = new JsonService("accounts.json");
            updateAccounts();
        }

        public void NotifyGenerateButtonClicked()
        {
            this.GeneratedPassword = GeneratorService.Generate();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        //Public Variables
      
        public List<Account>? Accounts
        {
            get => accountsList;
            set { 
                accountsList = value;
                OnPropertyChanged(nameof(Accounts));
            }
        }
        public string? GeneratedPassword
        {
            get => generatedPassword;
            set
            {
                this.generatedPassword = value;
                OnPropertyChanged(nameof(GeneratedPassword));
            }
        }
    }
}

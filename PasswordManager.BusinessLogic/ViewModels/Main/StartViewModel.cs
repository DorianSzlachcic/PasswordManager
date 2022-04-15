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
        private string? password;
        private string? login;
        private string? name;
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
        public void NotifyAddButtonClicked()
        {
            if((Name != "" && Name != null) && (Login != "" && Login != null) 
                && (Password != "" && Password != null))
            {
                jsonService.WriteToFile(new Account(Name, Login, SecurityService.EncryptAES(Password)));
                Name = null;
                Login = null;
                Password = null;
                updateAccounts();
            }
        }

        public void NotifyGenerateButtonClicked()
        {
            this.GeneratedPassword = GeneratorService.Generate();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        //Public Variables
        public string? Name
        {
            get => name;
            set
            {
                this.name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string? Login
        {
            get => login;
            set
            {
                this.login = value;
                OnPropertyChanged(nameof(Login));
            }
        }
        public string? Password 
        { 
            get => password;
            set 
            {
                this.password = value;
                OnPropertyChanged(nameof (Password));
            } 
        }
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

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
    public class MainWindowViewModel :INotifyPropertyChanged
    {
        private string? accountsList;
        private string? password;
        private string? login;
        private string? name;
        private string? generatedPassword;

        private JsonService jsonService;
        private GeneratorService generatorService;
        private SecurityService securityService;

        private void updateAccounts()
        {
            List<Account> list = jsonService.LoadFromFile();
            Accounts = "";
            foreach (Account acc in list)
            {
                Accounts += "Name: " + acc.Name + " Login: " + acc.Login + " Password: " + securityService.DecryptAES(acc.Password) + "\n";
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public MainWindowViewModel()
        {
            jsonService = new JsonService("accounts.json");
            generatorService = new GeneratorService();
            securityService = new SecurityService();
            updateAccounts();
        }
        public void NotifyAddButtonClicked()
        {
            if((Name != "" && Name != null) && (Login != "" && Login != null) 
                && (Password != "" && Password != null))
            {
                jsonService.WriteToFile(new Account(Name, Login, securityService.EncryptAES(Password)));
                Name = null;
                Login = null;
                Password = null;
                updateAccounts();
            }
        }

        public void NotifyGenerateButtonClicked()
        {
            this.GeneratedPassword = generatorService.Generate();
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
        public string? Accounts
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

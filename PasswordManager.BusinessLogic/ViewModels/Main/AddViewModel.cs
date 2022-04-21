using PasswordManager.BusinessLogic.Services.File;
using PasswordManager.BusinessLogic.Services.Password;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BusinessLogic.ViewModels.Main
{
    public class AddViewModel :INotifyPropertyChanged
    {
        private string? password;
        private string? login;
        private string? name;

        private JsonService jsonService;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public AddViewModel()
        {
            jsonService = new JsonService("accounts.json");
        }
        public void NotifyAddButtonClicked()
        {
            if ((Name != "" && Name != null) && (Login != "" && Login != null)
                && (Password != "" && Password != null))
            {
                jsonService.WriteToFile(new Account(Name, Login, SecurityService.EncryptAES(Password)));
                Name = null;
                Login = null;
                Password = null;
            }
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
                OnPropertyChanged(nameof(Password));
            }
        }
    }
}

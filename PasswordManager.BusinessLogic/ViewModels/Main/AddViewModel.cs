using PasswordManager.BusinessLogic.Services.File;
using PasswordManager.BusinessLogic.Models;
using PasswordManager.BusinessLogic.Services.Password;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BusinessLogic.ViewModels.Main
{
    public class AddViewModel : BaseScreenViewModel
    {
        private string? password;
        private string? login;
        private string? name;

        private JsonService jsonService;
        private SecurityService securityService;

        public AddViewModel(IChangeScreenHandler handler) : base(handler)
        {
            jsonService = new JsonService("accounts.json");
            securityService = new SecurityService();
        }
        public void NotifyAddButtonClicked()
        {
            if ((Name != "" && Name != null) && (Login != "" && Login != null)
                && (Password != "" && Password != null))
            {
                jsonService.WriteToFile(new Account(Name, Login, securityService.EncryptAES(Password)));
                Name = null;
                Login = null;
                Password = null;
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
    }
}

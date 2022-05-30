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
    public class AddViewModel : BaseScreenViewModel
    {
        private string? password;
        private string? login;
        private string? name;

        private ICommand addCommand;

        private ISqliteService sqliteService;
        private ISecurityService securityService;

        public AddViewModel(IChangeScreenHandler handler, ISqliteService sqliteService, ISecurityService securityService):base(handler)
        {
            this.sqliteService = sqliteService;
            this.securityService = securityService;

            addCommand = new AppCommand(obj => AddAccount());
        }
        public void AddAccount()
        {
            if ((Name != "" && Name != null) && (Login != "" && Login != null)
                && (Password != "" && Password != null))
            {
                sqliteService.SaveAccount(new Account(Name, Login, securityService.EncryptAES(Password)));
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

        public ICommand AddCommand
        {
            get => addCommand;
            set => Set(ref addCommand, value);
        }
    }
}

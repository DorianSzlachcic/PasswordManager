using PasswordManager.BusinessLogic.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BusinessLogic.ViewModels.Main
{ 
    public interface IChangeScreenHandler
    {
        void ChangeScreenToStartView();
        void ChangeScreenToAddView();
        void ChangeScreenToAccountsView();
    }
}

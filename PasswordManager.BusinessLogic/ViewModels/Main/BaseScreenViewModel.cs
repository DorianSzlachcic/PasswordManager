using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BusinessLogic.ViewModels.Main
{
    public abstract class BaseScreenViewModel :BaseViewModel
    {
        protected IChangeScreenHandler changeScreenHandler;

        public BaseScreenViewModel(IChangeScreenHandler handler)
        {
            changeScreenHandler = handler;
        }
    }
}

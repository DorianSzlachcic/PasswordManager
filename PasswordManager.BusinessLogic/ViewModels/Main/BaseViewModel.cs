using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PasswordManager.BusinessLogic.ViewModels.Main
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void Set<T>(ref T field, T value, [CallerMemberNameAttribute] string property = null)
        {
            field = value;
            OnPropertyChanged(property);
        }
    }
}

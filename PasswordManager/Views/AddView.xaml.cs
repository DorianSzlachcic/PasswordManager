using PasswordManager.BusinessLogic.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PasswordManager.Views
{
    /// <summary>
    /// Logika interakcji dla klasy AddView.xaml
    /// </summary>
    public partial class AddView : UserControl
    {
        private AddViewModel viewModel;
        public AddView()
        {
            InitializeComponent();
            viewModel = new AddViewModel();
            DataContext = viewModel;
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            viewModel.NotifyAddButtonClicked();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            parentWindow.ChangeViewToStartView();
        }
    }
}

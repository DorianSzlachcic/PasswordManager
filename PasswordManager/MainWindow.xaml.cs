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
using PasswordManager.BusinessLogic.ViewModels.Main;

namespace PasswordManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new StartViewModel();
        }
        
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ChangeViewToStartView();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataContext = new AccountsViewModel();
        }

        internal void ChangeViewToAddAccount()
        {
            DataContext = new AddViewModel();
        }

        internal void ChangeViewToStartView()
        {
            DataContext = new StartViewModel();
        }
    }
}

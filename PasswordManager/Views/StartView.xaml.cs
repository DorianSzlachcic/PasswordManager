﻿using PasswordManager.BusinessLogic.ViewModels.Main;
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
    /// Logika interakcji dla klasy StartView.xaml
    /// </summary>
    public partial class StartView : UserControl
    {
        private StartViewModel viewModel;

        public StartView()
        {
            InitializeComponent();
            viewModel = new StartViewModel();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            parentWindow.ChangeViewToAddAccount();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            viewModel.NotifyGenerateButtonClicked();
        }
    }
}

﻿using System;
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

namespace Clippy
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Page
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            //use the text boxes here to create the account and sign the individual into their account

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //Return to the login screen
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            var win = Window.GetWindow(this);
            win.Close();
        }
    }
}
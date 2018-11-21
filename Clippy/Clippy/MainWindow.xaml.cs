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

namespace Clippy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //This is the handling of logging in
            String username = Username.Text;
            String password = Password.Password;

            //Log in if username and password are valid

            //Switch to user's AppHome if valid login

            String temp = username + "   " + password;

            AppWindow home = new AppWindow();
            home.Show();
            this.Close();



        }

        /**
         * connectToUserAcct - helper to connect a user to their actual account. Called 
         * from LoginButton
         */
        private void connectToUserAcct(String username, String password)
        {

        }

        /**
         * Called from clicking a new account. Idk if I want to create an account in a new window 
         * or use a Usercontrol or a page sort of system. Page could be neat, although they are 
         * mostly used in the context of webpages.
         */
        private void NewAccount_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount acct = new CreateAccount();
            this.Content = acct;
            this.Height = 450;
            this.Width = 800;
        }
    }
}

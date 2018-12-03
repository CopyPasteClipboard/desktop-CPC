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

        #region Buttons

        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            //This is the handling of logging in
            String username = Username.Text;
            String password = Password.Password;

            if(username.Length > 0 && password.Length > 0)
            {

                //attempt log in API call (is what this should be)
                UserLoginInfoModel user = await connectToUserAcct(username, password);

                AppWindow home = new AppWindow(user);
                home.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please enter your username and password", "Empty Username/Password",
                    MessageBoxButton.OK);
            }
        }

        private void NewAccount_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount acct = new CreateAccount();
            this.Content = acct;
            this.Height = 450;
            this.Width = 800;
        }

        #endregion


        /**
         * connectToUserAcct - helper to connect a user to their actual account. Called 
         * from LoginButton
         */
        private async Task<UserLoginInfoModel> connectToUserAcct(String username, String password)
        {
            UserLoginInfoModel ret = new UserLoginInfoModel();

            //api calls to log in a user

            return ret;
        }
    }
}

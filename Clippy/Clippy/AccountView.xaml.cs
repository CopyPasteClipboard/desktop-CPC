using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
    /// Interaction logic for AccountView.xaml
    /// </summary>
    public partial class AccountView : Page
    { 
        public AccountView()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var win = Window.GetWindow(this);
            HomeScreen home = new HomeScreen();
            win.Content = home;
        }

        private void ConfirmChanges_Click(object sender, RoutedEventArgs e)
        {
            //update the acct
            AccountInfo acct = new AccountInfo();
            acct.username = EmailBox.Text;
            acct.password = PasswordBox.Password;
            acct.phone_number = PhoneNumBox.Text;
            UpdateAccount(acct);

            HomeScreen home = new HomeScreen();
            var win = Window.GetWindow(this);
            win.Content = home;

        }

        private async Task<AccountInfo> UpdateAccount(AccountInfo acct)
        {
            //UPDATE THE BELOW LINE WITH PROPER :userid
            HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync("v1/user/:userid", acct);
            response.EnsureSuccessStatusCode();
            AccountInfo ret = await response.Content.ReadAsAsync<AccountInfo>();
            return ret;
        }

        private void DeleteAcct_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult deleteAcct = 
                MessageBox.Show("Are you sure you want to delete this account?","Account Deletion",
                MessageBoxButton.YesNo);

            if (deleteAcct==MessageBoxResult.Yes)
            {
                //Delete the account
                DeleteAccountRequest();
                MainWindow login_screen = new MainWindow();
                login_screen.Show();
                var old_window = Window.GetWindow(this);
                old_window.Close();
            }
            else
            {
                var win = Window.GetWindow(this);
                HomeScreen home = new HomeScreen();
                win.Content = home;
            }
        }

        private async Task<HttpStatusCode> DeleteAccountRequest()
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync("v1/user/:userid");
            return response.StatusCode;
        }
    }
}

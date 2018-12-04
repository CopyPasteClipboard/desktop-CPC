﻿using Clippy.ApiClasses;
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
        private CurrentUser User;

        public AccountView(CurrentUser user)
        {
            InitializeComponent();
            User = user;
            NameBox.Text = "Jane Doe";
            EmailBox.Text = User.GetUsername();
        }

        #region Buttons

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var win = Window.GetWindow(this);
            HomeScreen home = new HomeScreen(User);
            win.Content = home;
        }

        private void ConfirmChanges_Click(object sender, RoutedEventArgs e)
        {
            //update the acct
            AccountInfoModel acct = new AccountInfoModel();
            acct.username = EmailBox.Text;
            acct.password = PasswordBox.Password;
            acct.phone_number = PhoneNumBox.Text;

            try
            {
                UpdateAccount(acct);
            }
            catch (HttpRequestException)
            {
                MessageBox.Show("API Connection Failure");
            }

            HomeScreen home = new HomeScreen(User);
            var win = Window.GetWindow(this);
            win.Content = home;

        }

        private void DeleteAcct_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult deleteAcct =
                MessageBox.Show("Are you sure you want to delete this account?", "Account Deletion",
                MessageBoxButton.YesNo);

            if (deleteAcct == MessageBoxResult.Yes)
            {
                //Delete the account

                try
                {
                    DeleteAccountRequest();
                }
                catch (HttpRequestException)
                {
                    MessageBox.Show("API Connection Failure");
                }
                MainWindow login_screen = new MainWindow();
                login_screen.Show();
                var old_window = Window.GetWindow(this);
                old_window.Close();
            }
            else
            {
                var win = Window.GetWindow(this);
                HomeScreen home = new HomeScreen(User);
                win.Content = home;
            }
        }

        #endregion

        #region API Queries

        private async Task<AccountInfoModel> UpdateAccount(AccountInfoModel acct)
        {
            //UPDATE THE BELOW LINE WITH PROPER :userid
            HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync("v1/user/:userid", acct);
            response.EnsureSuccessStatusCode();
            AccountInfoModel ret = await response.Content.ReadAsAsync<AccountInfoModel>();
            return ret;
        }

        private async Task<HttpStatusCode> DeleteAccountRequest()
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync("v1/user/:userid");
            return response.StatusCode;
        }

        #endregion
    }
}

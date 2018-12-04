using Clippy.ApiClasses;
using System;
using System.Collections.Generic;
using System.Linq;
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
    /// Interaction logic for CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Page
    {
        public CreateAccount()
        {
            InitializeComponent();
        }

        #region Buttons

        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            //use the text boxes here to create the account and sign the individual into their account
            if (!EmailBox.Text.Trim().Equals("") &&
                !PasswordBox.Password.Trim().Equals("") &&
                !PhoneNumBox.Text.Trim().Equals(""))
            {
                CreateAccountModel acct = new CreateAccountModel();
                acct.username = this.EmailBox.Text;
                acct.password = this.PasswordBox.Password;
                acct.phone_number = this.PhoneNumBox.Text;

                try
                {
                    PostNewAcct(acct);
                }
                catch (HttpRequestException) {
                    MessageBox.Show("API Connection Failure");
                }
            }
            else
            {
                MessageBox.Show("Please enter all information",
                    "Invalid Account Information", MessageBoxButton.OK);
            }

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //Return to the login screen
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            var win = Window.GetWindow(this);
            win.Close();
        }

        #endregion

        /// <summary>
        /// New Account API Post
        /// </summary>
        /// <param name="acct">
        /// AccountInfoModel for API post
        /// </param>
        /// <returns>
        /// Post location
        /// </returns>
        private async Task<Uri> PostNewAcct(CreateAccountModel acct)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync("/v1/user",acct);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
    }
}

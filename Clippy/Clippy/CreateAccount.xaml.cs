using Clippy.ApiClasses;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Clippy
{
    /// <summary>
    /// Interaction logic for CreateAccount.xaml page interaction. Instantiated
    /// from MainWindow log in screen using the "Create Account" button
    /// Created be Keola Dunn
    /// </summary>
    public partial class CreateAccount : Page
    {
        /// <summary>
        /// Simple CreateAccount page constructor
        /// </summary>
        public CreateAccount()
        {
            InitializeComponent();
        }

        #region Buttons

        /// <summary>
        /// Confirm account creation, and send the API request to create the account.
        /// After account creation, returns the user to the log in screen, where they
        /// will have to log in with their new account information.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateAccount_Click(object sender, RoutedEventArgs e)
        {
            // verify that the user has given adequate input
            if (!EmailBox.Text.Trim().Equals("") &&
                !PasswordBox.Password.Trim().Equals("") &&
                !PhoneNumBox.Text.Trim().Equals(""))
            {
                //Load content into CreateAccountModel
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
                // User did not include all required information
                MessageBox.Show("Please enter all information",
                    "Invalid Account Information", MessageBoxButton.OK);
            }

            MessageBox.Show("Account created! Please sign in with your new " +
                "credentials!", "Account Successfully Created!", MessageBoxButton.OK);
            // return the user to the log in screen. In the future, implement log
            // in content as its own page
            MainWindow newWindow = new MainWindow();
            newWindow.Show(); 
            var win = Window.GetWindow(this);
            win.Close();
        }

        /// <summary>
        /// Cancel the account creation and return the user to the Log In screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            //Return to the login screen
            MainWindow newWindow = new MainWindow();
            newWindow.Show();
            var win = Window.GetWindow(this);
            win.Close();
        }

        #endregion

        #region ApiMethods

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

        #endregion

    }
}

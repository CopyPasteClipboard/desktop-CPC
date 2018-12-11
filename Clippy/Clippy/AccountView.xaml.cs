using Clippy.ApiClasses;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Clippy
{
    /// <summary>
    /// This is the Interaction logic for AccountView.xaml. It serves as the
    /// logic behind the AccountView page, such as buttons and API requests
    /// Created by Keola Dunn
    /// </summary>
    public partial class AccountView : Page
    {
        //user data 
        private CurrentUser User;

        /// <summary>
        /// Ctor to create the page and initial contents
        /// </summary>
        /// <param name="user">
        /// CurrentUser object containing all of the pertinent user data
        /// </param>
        public AccountView(CurrentUser user)
        {
            InitializeComponent();
            User = user;
            NameBox.Text = "Jane Doe";
            EmailBox.Text = User.GetUsername();
            //Other fields would be set here in the same way as above
        }

        #region Buttons

        /// <summary>
        /// button logic to return to HomeScreen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var win = Window.GetWindow(this);
            HomeScreen home = new HomeScreen(User);
            win.Content = home;
        }

        /// <summary>
        /// Button logic to commit changes to a user account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Button logic to delete an account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteAcct_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult deleteAcct =
                MessageBox.Show("Are you sure you want to delete this account?", "Account Deletion",
                MessageBoxButton.YesNo);

            if (deleteAcct == MessageBoxResult.Yes)
            {
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

        /// <summary>
        /// API call to update account information
        /// </summary>
        /// <param name="acct">
        /// AccountInfoModel class containing all of the information to update a class
        /// </param>
        /// <returns>
        /// Returns an AccountInfoModel containing all of the updated class information
        /// </returns>
        private async Task<AccountInfoModel> UpdateAccount(AccountInfoModel acct)
        {    
            HttpResponseMessage response = await ApiHelper.ApiClient.PutAsJsonAsync("v1/user/"+User.GetUserId().ToString(), acct);
            response.EnsureSuccessStatusCode();
            AccountInfoModel ret = await response.Content.ReadAsAsync<AccountInfoModel>();
            return ret;
        }

        /// <summary>
        /// API call tp delete an account
        /// </summary>
        /// <returns>
        /// Status of the API call
        /// </returns>
        private async Task<HttpStatusCode> DeleteAccountRequest()
        {

            HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync("v1/user/"+User.GetUserId().ToString());
            return response.StatusCode;
        }

        #endregion
    }
}

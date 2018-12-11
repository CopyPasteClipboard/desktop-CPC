using Clippy.ApiClasses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;

namespace Clippy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml inital application window
    /// Created by Keola Dunn
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// MainWindow simple ctor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #region Buttons

        /// <summary>
        /// Log in logic when "Log In" button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            // This is the handling of logging in
            String username = Username.Text;
            String password = Password.Password;

            // insure username and password are not empty lengths 
            if(username.Length > 0 && password.Length > 0)
            {
                LoginButton.IsEnabled = false;
                NewAccount.IsEnabled = false;
                //attempt log in API call 
                try
                {
                    // await response because we do not want to proceed until
                    // log in is validated
                    UserLoginInfoModel user = 
                        await connectToUserAcct(username, password);
                    if (user.id != -1)
                    {
                        // User log in was successful
                        AppWindow home = new AppWindow(user);
                        home.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Invalid Username/Password");
                        LoginButton.IsEnabled = true;
                        NewAccount.IsEnabled = true;
                    }
                }
                catch (HttpRequestException)
                {
                    var result = MessageBox.Show(
                        "Connection Failed Successfully. Yes to continue without account, " +
                        "No to re-attempt login, Cancel to close the application",
                        "No API Response", MessageBoxButton.YesNoCancel);

                    if(result == MessageBoxResult.Yes)
                    {
                        // This is a simulated log in available if the API is down for testing
                        // purposes only
                        UserLoginInfoModel user = new UserLoginInfoModel();
                        user.id = 0;
                        user.username = "Jane_Doe@fake.scam";
                        user.inserted_at = "potatoes";
                        AppWindow home = new AppWindow(user);
                        home.Show();
                        this.Close();
                    }else if(result == MessageBoxResult.Cancel)
                    {
                        this.Close();
                    }
                    else
                    {
                        LoginButton.IsEnabled = true;
                        NewAccount.IsEnabled = true;
                    }

                }
            }
            else
            {
                MessageBox.Show("Please enter your username and password", "Empty Username/Password",
                    MessageBoxButton.OK);
            }
        }

        /// <summary>
        /// Button logic for selection of "Create Account"
        /// Opens a create account page instance 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewAccount_Click(object sender, RoutedEventArgs e)
        {
            CreateAccount acct = new CreateAccount();
            this.Content = acct;
            this.Height = 450;
            this.Width = 800;
        }

        #endregion

        #region API Calls

        /// <summary>
        /// Attempts the API log in request to log a user into the application
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns>
        /// UserLoginInfoModel containing all of the user's info from login
        /// </returns>
        private async Task<UserLoginInfoModel> connectToUserAcct(String username, String password)
        {
            UserLoginInfoModel ret = new UserLoginInfoModel();

            SimpleLoginPostModel loginInfo = new SimpleLoginPostModel();
            loginInfo.username = username;

            if (ApiHelper.ApiClient == null)
            {
                ApiHelper.InitializeClient();
            }

            HttpResponseMessage response = 
                await ApiHelper.ApiClient.PostAsJsonAsync("/v1/login", loginInfo);

            if (response.IsSuccessStatusCode)
            {
                var a = response.ToString();

                string content = await response.Content.ReadAsStringAsync();
                ret = JsonConvert.DeserializeObject<UserLoginInfoModel>(content);
            }
            

            //id (int)
            //username (string)
            //inserted_at (date time)

            return ret;
        }

        #endregion
    }
}

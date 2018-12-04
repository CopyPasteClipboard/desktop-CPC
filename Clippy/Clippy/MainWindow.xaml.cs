using Clippy.ApiClasses;
using Newtonsoft.Json;
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
                try
                {
                    UserLoginInfoModel user = await connectToUserAcct(username, password);
                    AppWindow home = new AppWindow(user);
                    home.Show();
                    this.Close();
                }
                catch (HttpRequestException)
                {
                    var result = MessageBox.Show(
                        "Connection Failed Successfully. Yes to continue without account, " +
                        "No to re-attempt login, Cancel to close the application",
                        "No API Response", MessageBoxButton.YesNoCancel);

                    if(result == MessageBoxResult.Yes)
                    {
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
                }
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

            SimpleLoginPostModel loginInfo = new SimpleLoginPostModel();
            loginInfo.username = username;

            if (ApiHelper.ApiClient == null)
            {
                ApiHelper.InitializeClient();
            }

            HttpResponseMessage response = 
                await ApiHelper.ApiClient.PostAsJsonAsync("/v1/login", loginInfo);
            ret = JsonConvert.DeserializeObject<UserLoginInfoModel>(response.Content.ToString());
            

            //id (int)
            //username (string)
            //inserted_at (date time)

            return ret;
        }
    }
}

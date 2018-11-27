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
    /// Interaction logic for HomeScreen.xaml
    /// </summary>
    public partial class HomeScreen : Page
    {
        
        public HomeScreen()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            SetupHomeScreen();
           
        }

        private async void SetupHomeScreen()
        {
            ClipboardsModel boards = null;
            //boards = await getClipboards();
            //Need to uncomment the above line, delete the below when the source is correct
            boards = new ClipboardsModel();
            
            List<String> boardNames = boards.GetClipboardNames();
            this.User_Clipboards.ItemsSource = boardNames;
            User_Clipboards.SelectedIndex = User_Clipboards.SelectedIndex = 0;


            //Need to pass in an instance of a board object here I think
            List<String> boardContent = await getClipboardContent();
        }

        //THIS NEEDS WORK
        private async Task<List<String>> getClipboardContent()
        {
            return new List<String>();
        }

        private static async Task<ClipboardsModel> getClipboards()
        {
            ClipboardsModel clipboards = null;

            //THIS LOCATION IS NOT CORRECT IM 99% CERTAIN. AT BARE MINIMUM, PUT FAKE :userid IN PLACE
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync("v1/user/:userid/clipoards");
            if (response.IsSuccessStatusCode)
            {
                clipboards = await response.Content.ReadAsAsync<ClipboardsModel>();
            }
            return clipboards;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

            //Do the things to disconnect the app from the account, save state, and return to the login window
            MainWindow home = new MainWindow();
            home.Show();
            var win = Window.GetWindow(this);
            win.Close();


        }

        private void Copy_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("THIS IS MEANT TO COPY FROM CLIPBOARD");
        }

        private void Paste_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("THIS IS MEANT TO PASTE TO THE CLIPBOARD");
        }

        private void GetLast_Click(object sender, RoutedEventArgs e)
        {
            var last = VisualClipboard.ContentEnd;
            Clipboard.SetText(last.ToString());
        }

        private void AddLatest_Click(object sender, RoutedEventArgs e)
        {
            //NEED TO UPDATE THE CLIPBOARD HERE
        }

        private void NewClipboard_Click(object sender, RoutedEventArgs e)
        {
            NewClipboard create = new NewClipboard();
            var win = Window.GetWindow(this);
            win.Content = create;
        }

        private void DeleteClipboard_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to delete \"" + User_Clipboards.Text + "\"?"
                , "Delete Clipboard?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                //delete the clipboard
            }
        }

        private void Account_Click(object sender, RoutedEventArgs e)
        {
            AccountView acct = new AccountView();
            var win = Window.GetWindow(this);
            win.Content = acct;
        }
    }
}

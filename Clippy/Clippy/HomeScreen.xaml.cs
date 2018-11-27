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
            boards = await getClipboards();
            
            List<String> boardNames = boards.GetClipboardNames();
            this.User_Clipboards.ItemsSource = boardNames;
            User_Clipboards.SelectedIndex = User_Clipboards.SelectedIndex = 0;


            //Need to pass in an instance of a board object here I think
            List<String> boardContent = await getClipboardContent();
            VisualClipboard.ItemsSource = boardContent;
        }

        #region Buttons

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

            //Do the things to disconnect the app from the account, save state, and return to the login window
            MainWindow home = new MainWindow();
            home.Show();
            var win = Window.GetWindow(this);
            win.Close();
        }

        private void GetLast_Click(object sender, RoutedEventArgs e)
        {
            VisualClipboard.SelectedIndex = VisualClipboard.Items.Count - 1;
            String content = VisualClipboard.SelectedItem.ToString();
            Clipboard.SetText(content);
        }

        private void AddLatest_Click(object sender, RoutedEventArgs e)
        {
            updateClipboard();
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

        private void SimpleCopy_Click(object sender, RoutedEventArgs e)
        {
            if (VisualClipboard.SelectedIndex > -1)
            {
                String content = VisualClipboard.SelectedItem.ToString();
                Clipboard.SetText(content);
            }
        }

        private async void Refresh_Click(object sender, RoutedEventArgs e)
        {
            List<String> clipboardContent = await getClipboardContent();
            VisualClipboard.ItemsSource = clipboardContent;
        }


        #endregion

        #region API Queries

        private async Task<List<String>> getClipboardContent()
        {
            List<String> ret = new List<String>();

            ret.Add("Audi");
            ret.Add("BMW");
            ret.Add("Chevrolet");
            ret.Add("Dodge");
            ret.Add("Ford");
            ret.Add("Fiat");
            ret.Add("GMC");
            ret.Add("Subaru");
            ret.Add("Mercedes");
            ret.Add("Nissan");
            ret.Add("Datsun");
            return ret;
        }

        private static async Task<ClipboardsModel> getClipboards()
        {
            ClipboardsModel clipboards = null;

            //0 is the temporary demo :userid
            HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync("v1/user/0/clipoards");
            if (response.IsSuccessStatusCode)
            {
                clipboards = await response.Content.ReadAsAsync<ClipboardsModel>();
            }
            return clipboards;
        }

        private static async Task<Uri> updateClipboard()
        {
            string new_item = Clipboard.GetText(TextDataFormat.Text);
            NewClipboardItem item = new NewClipboardItem();
            item.new_item = new_item;

            //NEED TO UPDATE BOARD ID
            HttpResponseMessage response =
                await ApiHelper.ApiClient.PostAsJsonAsync("v1/clipboard/:boardid/boarditem", item);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        #endregion
    }
}

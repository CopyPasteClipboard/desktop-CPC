using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

        private CurrentUser User;

        /// <summary>
        /// constructor that creates an application homescreen page
        /// </summary>
        public HomeScreen(CurrentUser user)
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
            User = user;
            SetupHomeScreen();
        }

        /// <summary>
        /// Set the values of the HomeScreen that rely on API returned values.
        /// asynch method
        /// </summary>
        private async void SetupHomeScreen()
        {
            //Gets all the clipboard names to be displayed on the homescreen
            List<ClipboardModel> boards = null;
            boards = await GetClipboards();

            List<String> boardNames = new List<String>();

            if (boards != null)
            {
                foreach (ClipboardModel board in boards)
                {
                    boardNames.Add(board.board_name);
                }

                User.SetClipboards(boards);
            }

            this.User_Clipboards.ItemsSource = boardNames;
            User_Clipboards.SelectedIndex = User_Clipboards.SelectedIndex = 0;

            //Gets all of the initial board contents to display on the home screen
            List<ClipboardContentsModel> boardContents = await GetClipboardContent();
            List<String> content = new List<String>();
            if (boardContents != null)
            {
                foreach (ClipboardContentsModel board in boardContents)
                {
                    content.Add(board.text_content);
                }
            }
            VisualClipboard.ItemsSource = content;
        }

        #region Buttons

        /// <summary>
        /// Logs the user out and closes the HomeScreen, returning to MainWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Logout_Click(object sender, RoutedEventArgs e)
        {

            //Do the things to disconnect the app from the account, save state, and return to the login window
            MainWindow home = new MainWindow();
            home.Show();
            var win = Window.GetWindow(this);
            win.Close();
        }

        /// <summary>
        /// Adds the last added item in Clippy to the local windows clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetLast_Click(object sender, RoutedEventArgs e)
        {
            if (VisualClipboard.Items.Count > 0)
            {
                VisualClipboard.SelectedIndex = VisualClipboard.Items.Count - 1;
                String content = VisualClipboard.SelectedItem.ToString();
                Clipboard.SetText(content);
            }
        }

        /// <summary>
        /// Adds the item from the local clipboard to the Clippy board.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddLatest_Click(object sender, RoutedEventArgs e)
        {
            UpdateClipboard();
            SetupHomeScreen();
        }

        /// <summary>
        /// Creates a new clipboard for the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewClipboard_Click(object sender, RoutedEventArgs e)
        {
            NewClipboard create = new NewClipboard(User);
            var win = Window.GetWindow(this);
            win.Content = create;
        }

        /// <summary>
        /// Deletes a user clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void DeleteClipboard_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = 
                MessageBox.Show("Are you sure you want to delete \"" + User_Clipboards.Text + "\"?"
                , "Delete Clipboard?", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                //delete the clipboard
                string uri = "/v1/clipboard/" + User.GetBoardId(User_Clipboards.Text);
                HttpResponseMessage response = await ApiHelper.ApiClient.DeleteAsync(uri);
            }
        }

        /// <summary>
        /// Opens an AccountView for the user to see/update their account information
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Account_Click(object sender, RoutedEventArgs e)
        {
            AccountView acct = new AccountView(User);
            var win = Window.GetWindow(this);
            win.Content = acct;
        }

        /// <summary>
        /// Simple copy from the Clippy clipboard to local windows clipboard.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SimpleCopy_Click(object sender, RoutedEventArgs e)
        {
            if (VisualClipboard.SelectedIndex > -1)
            {
                String content = VisualClipboard.SelectedItem.ToString();
                Clipboard.SetText(content);
            }
        }

        /// <summary>
        /// Reloads the HomeScreen elements to get new clipboards/clipboard items.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Refresh_Click(object sender, RoutedEventArgs e)
        {
            SetupHomeScreen();
        }

        #endregion


        #region API Queries

        /// <summary>
        /// Gets the content of a Clippy clipboard.
        /// </summary>
        /// <returns>List of ClipboardContentsModels</returns>
        private async Task<List<ClipboardContentsModel>> GetClipboardContent()
        {
            string uri = "/v1/clipboard/" + User.GetUserId() +"?type=mostRecent || type=all";
            String response = 
                await ApiHelper.ApiClient.GetStringAsync(uri);
            //[{"id":6,"board_id":"0","text_content":"hi keaton"}] = Json example string in response
            List<ClipboardContentsModel> content = 
                JsonConvert.DeserializeObject<List<ClipboardContentsModel>>(response);
            return content;
        }

        /// <summary>
        /// Gets all of the user's clipboards
        /// </summary>
        /// <returns>List of ClipboardModels</returns>
        private async Task<List<ClipboardModel>> GetClipboards()
        {
            //Hard coded :userid as 0 for the demo

            //HttpClient client = new HttpClient();


            //String other_addr = "http://34.224.86.78:8080/v1/clipboard/0/boarditem";
            //NewClipboardItem ok = new NewClipboardItem();
            //ok.new_item = "420";
            //var add = JsonConvert.SerializeObject(ok);
            //Trace.WriteLine(add);
            //var buffer = System.Text.Encoding.UTF8.GetBytes(add);
            //var byteContent = new ByteArrayContent(buffer);
            //await client.PostAsync(other_addr, byteContent);


            //This line works for API requests. 
            //await ApiHelper.ApiClient.PostAsJsonAsync("/v1/clipboard/0/boarditem", ok);


            //user = bananaland
            //password = coffeeyummy


            //String addr = "http://34.224.86.78:8080/v1/user/0/clipboards";



            //AppWindow myWin = Window.GetWindow(this) as Clippy.AppWindow;
            //string id = myWin.GetUserId().ToString();
            string uri = "/v1/user/" + User.GetUserId() + "/clipboards";
            String response = await ApiHelper.ApiClient.GetStringAsync(uri);
            var data = JsonConvert.DeserializeObject<List<ClipboardModel>>(response);
            return data;
        }

        /// <summary>
        /// Adds a new item to a Clippy clipboard
        /// </summary>
        /// <returns>Uri of API call</returns>
        private async Task<Uri> UpdateClipboard()
        {
            string new_item = Clipboard.GetText(TextDataFormat.Text);
            NewClipboardItem item = new NewClipboardItem();
            item.new_item = new_item;

            string uri = "/v1/clipboard/" + User.GetBoardId(this.User_Clipboards.Text)
                + "/boarditem";
            HttpResponseMessage response =
                await ApiHelper.ApiClient.PostAsJsonAsync(uri, item);
            response.EnsureSuccessStatusCode();
            
            return response.Headers.Location;
        }

        #endregion

        private async void User_Clipboards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String new_selection = e.AddedItems[0].ToString();
            //Change the ListBox to contain the elements of the other board.

            List<ClipboardContentsModel> boardContents = await GetClipboardContent();

            List<String> content = new List<String>();

            if (boardContents != null)
            {
                foreach (ClipboardContentsModel item in boardContents)
                {
                    content.Add(item.text_content);
                }
            }
            VisualClipboard.ItemsSource = content;
        }
    }
}

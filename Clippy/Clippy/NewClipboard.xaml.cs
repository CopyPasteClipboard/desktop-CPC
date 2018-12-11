using Clippy.ApiClasses;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Clippy
{
    /// <summary>
    /// Interaction logic for NewClipboard.xaml page
    /// Created by Keola Dunn
    /// </summary>
    public partial class NewClipboard : Page
    {
        // User data
        private CurrentUser User = null;

        /// <summary>
        /// Ctor to create the NewClipboard page
        /// </summary>
        /// <param name="user"></param>
        public NewClipboard(CurrentUser user)
        {
            InitializeComponent();
            User = user;
        }

        /// <summary>
        /// Button logic for new clipboard creation confirmation. Generates the
        /// API request for a new clipboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmChanges_Click(object sender, RoutedEventArgs e)
        {
            //UPDATE THE USER ID THING HERE
            NewClipboardModel board = new NewClipboardModel();
            board.board_name = this.NameBox.Text;

            //LOL UPDATE THIS ASAP
            board.user_id = User.GetUserId(); //"SOME USERID THAT I NEED TO GET FROM SOMEWHERE";

            try
            {
                AddNewClipboard(board);
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
        /// Logic to cancel new clipboard creation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen home = new HomeScreen(User);
            var win = Window.GetWindow(this);
            win.Content = home;
        }

        /// <summary>
        /// API call to actually create the new clipboard
        /// </summary>
        /// <param name="board"></param>
        /// <returns>
        /// Uri of the new clipboard
        /// </returns>
        private async Task<Uri> AddNewClipboard(NewClipboardModel board)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync("v1/clipboard", board);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
    }
}

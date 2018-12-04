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
    /// Interaction logic for NewClipboard.xaml
    /// </summary>
    public partial class NewClipboard : Page
    {

        private CurrentUser User = null;

        public NewClipboard(CurrentUser user)
        {
            InitializeComponent();
            User = user;
        }

        private void ConfirmChanges_Click(object sender, RoutedEventArgs e)
        {
            //UPDATE THE USER ID THING HERE
            ClipboardModel board = new ClipboardModel();
            board.board_name = this.NameBox.Text;



            //LOL UPDATE THIS ASAP
            board.id = 6; //"SOME USERID THAT I NEED TO GET FROM SOMEWHERE";




            AddNewClipboard(board);

            HomeScreen home = new HomeScreen(User);
            var win = Window.GetWindow(this);
            win.Content = home;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen home = new HomeScreen(User);
            var win = Window.GetWindow(this);
            win.Content = home;
        }

        private async Task<Uri> AddNewClipboard(ClipboardModel board)
        {
            HttpResponseMessage response = await ApiHelper.ApiClient.PostAsJsonAsync("v1/clipboard", board);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }
    }
}

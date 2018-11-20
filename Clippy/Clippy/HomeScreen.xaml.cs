using System;
using System.Collections.Generic;
using System.Linq;
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

        }

        private void AddLatest_Click(object sender, RoutedEventArgs e)
        {

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

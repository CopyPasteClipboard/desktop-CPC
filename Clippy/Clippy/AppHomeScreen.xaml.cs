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
using System.Windows.Shapes;

namespace Clippy
{
    /// <summary>
    /// Interaction logic for AppHomeScreen.xaml
    /// </summary>
    public partial class AppHomeScreen : Window
    {
        public AppHomeScreen()
        {
            InitializeComponent();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

            //Do the things to disconnect the app from the account, save state, and return to the login window
            MainWindow home = new MainWindow();
            home.Show();
            this.Close();


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
    }
}

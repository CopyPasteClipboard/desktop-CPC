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
    /// Interaction logic for AccountView.xaml
    /// </summary>
    public partial class AccountView : Page
    {
        private bool changed = false;

        public AccountView()
        {
            InitializeComponent();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            var win = Window.GetWindow(this);
            HomeScreen home = new HomeScreen();
            win.Content = home;
        }

        private void ConfirmChanges_Click(object sender, RoutedEventArgs e)
        {
            if (changed)
            {
                //update the acct
            }
            else
            {
              
            }
        }
    }
}

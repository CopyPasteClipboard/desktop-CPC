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
    /// Interaction logic for NewClipboard.xaml
    /// </summary>
    public partial class NewClipboard : Page
    {
        public NewClipboard()
        {
            InitializeComponent();
        }

        private void ConfirmChanges_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            HomeScreen home = new HomeScreen();
            var win = Window.GetWindow(this);
            win.Content = home;
        }
    }
}

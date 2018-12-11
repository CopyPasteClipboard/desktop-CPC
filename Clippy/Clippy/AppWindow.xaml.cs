using System.Windows;

namespace Clippy
{
    /// <summary>
    /// Interaction logic for AppWindow.xaml
    /// Creates the window used for most main application functionalities
    /// Created by Keola Dunn
    /// </summary>
    public partial class AppWindow : Window
    {
        /// <summary>
        /// ctor that converts a UserLoginInfoModel to a CurrentUser
        /// </summary>
        /// <param name="loginInfo">
        /// UserLoginInfoModel to be converted to a CurrentUser for the each use cycle
        /// of the application
        /// </param>
        public AppWindow(UserLoginInfoModel loginInfo)
        {
            InitializeComponent();
            CurrentUser user = new CurrentUser(loginInfo);
            HomeScreen home = new HomeScreen(user);
            this.Content = home;
        }

    }
}

﻿using System;
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
    /// Interaction logic for AppWindow.xaml
    /// Creates the window for main application functionality
    /// </summary>
    public partial class AppWindow : Window
    {
        /// <summary>
        /// ctor that converts a UserLoginInfoModel to a CurrentUser
        /// </summary>
        /// <param name="loginInfo"></param>
        public AppWindow(UserLoginInfoModel loginInfo)
        {
            InitializeComponent();
            CurrentUser user = new CurrentUser(loginInfo);
            HomeScreen home = new HomeScreen(user);
            this.Content = home;
        }
    }
}

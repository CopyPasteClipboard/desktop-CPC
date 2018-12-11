using System.Windows;
using System.Windows.Controls;
using Clippy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClippyTests
{
    /// <summary>
    /// Class that performs the integration testing for the Clippy application.
    /// These tests are focused at slightly larger application components to 
    /// insure that all parts are working together as intended
    /// Created by Keola Dunn
    /// </summary>
    [TestClass]
    public class ClippyIntegrationTests
    {
        /// <summary>
        /// Basic App Window test to see if a window is created
        /// </summary>
        [TestMethod]
        public void TestAppWindow1()
        {
            //Note: App window does not have many testable methods
            UserLoginInfoModel info = new UserLoginInfoModel();
            AppWindow window = new AppWindow(info);
            Assert.IsNotNull(window);
            Assert.IsTrue(window is Window);
        }

        /// <summary>
        /// HomeScreen test to insure that the home screen is created successfully
        /// </summary>
        [TestMethod]
        public void TestHomeScreen1()
        {
            CurrentUser user = CreateCurrentUser();
            HomeScreen home = new HomeScreen(user);

            Assert.IsNotNull(home);
            Assert.IsTrue(home is Page);
        }

        /// <summary>
        /// AccountView test to insure that an accountview was created correctly
        /// </summary>
        [TestMethod]
        public void TestAccountView1()
        {
            CurrentUser user = CreateCurrentUser();
            AccountView acct = new AccountView(user);
            Assert.IsNotNull(acct);
            Assert.IsTrue(acct is Page);
            Assert.IsTrue(acct is AccountView);
        }

        /// <summary>
        /// CreateAccount test to insure that the CreateAccount page was created
        /// successfully
        /// </summary>
        [TestMethod]
        public void TestCreateAccount1()
        {
            CreateAccount acct = new CreateAccount();
            Assert.IsNotNull(acct);
            Assert.IsTrue(acct is Page);
        }

        /// <summary>
        /// NewClipboard test to insure that the NewClipboard page was created
        /// successfully
        /// </summary>
        [TestMethod]
        public void TestNewClipboard1()
        {
            CurrentUser user = CreateCurrentUser();
            NewClipboard clipboard = new NewClipboard(user);
            Assert.IsNotNull(clipboard);
            Assert.IsTrue(clipboard is Page);
        }

        /// <summary>
        /// Helper method to create a CurrentUser to test with
        /// </summary>
        /// <returns>
        /// Returns a CurrentUser instance with testable contents
        /// </returns>
        private CurrentUser CreateCurrentUser()
        {
            UserLoginInfoModel info = new UserLoginInfoModel();
            info.id = 1;
            info.inserted_at = "";
            info.username = "clippyuser";
            return new CurrentUser(info);
        }
    }
}

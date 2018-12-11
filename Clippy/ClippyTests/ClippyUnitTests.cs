using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clippy;
using System.Collections.Generic;
using System.Net.Http;
using Clippy.ApiClasses;

namespace ClippyTests
{
    /// <summary>
    /// ClippyUnitTests class implementing the unit tests for the application
    /// These tests are aimed at the smaller portions of the application, making
    /// sure that members are set correctly and methods function as intended.
    /// Additionally, they will indicate errors if, in future application versions,
    /// these fundamental components are changed.
    /// Created by Keola Dunn
    /// </summary>
    [TestClass]
    public class ClippyUnitTests
    {
        [TestMethod]
        public void TestCurrentUserCtor1()
        {
            UserLoginInfoModel login = new UserLoginInfoModel();
            login.id = 1;
            login.inserted_at = "123-456-7899";
            login.username = "Jane@doe.scam";

            CurrentUser user = new CurrentUser(login);

            Assert.AreEqual(user.GetUserId(), login.id);
            Assert.AreEqual(user.GetUsername(), login.username);
        }

        [TestMethod]
        public void TestCurrentUserCtor2()
        {
            UserLoginInfoModel login = new UserLoginInfoModel();
            login.id = -1;
            login.inserted_at = null;
            login.username = "Jane@doe.scam";

            CurrentUser user = new CurrentUser(login);

            Assert.AreEqual(user.GetUserId(), login.id);
            Assert.AreEqual(user.GetPhoneNumber(), null);
            Assert.AreEqual(user.GetUsername(), login.username);
        }

        [TestMethod]
        public void TestCurrentUserBoards1()
        {
            List<ClipboardModel> clipboards = new List<ClipboardModel>();
            for(int i = 1; i<=500; ++i)
            {
                ClipboardModel board = new ClipboardModel();
                string boardName = "";
                for(int j = 0; j<i; ++j)
                {
                    boardName = boardName + "i";
                }
                board.board_name = boardName;
                board.id = i;
                clipboards.Add(board);
            }

            UserLoginInfoModel login = new UserLoginInfoModel();
            login.id = 1;
            login.inserted_at = null;
            login.username = "Jane@doe.scam";

            CurrentUser user = new CurrentUser(login);
            user.SetClipboards(clipboards);
            String test = "iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii";
            Assert.AreEqual(user.GetBoardId("iiiii"), 5);
            Assert.AreEqual(user.GetBoardId(test),test.Length);
            Assert.AreEqual(user.GetBoardId(""), -1);
            Assert.AreEqual(user.GetBoardId("iabcd"), -1);
        }

        [TestMethod]
        public void TestCurrentUserGetPhone()
        {
            UserLoginInfoModel login = new UserLoginInfoModel();
            login.id = -1;
            login.inserted_at = null;
            login.username = "Jane@doe.scam";

            CurrentUser user = new CurrentUser(login);
            Assert.IsNull(user.GetPhoneNumber());
        }

        [TestMethod]
        public void TestApiHelper1()
        {
            Assert.AreEqual(ApiHelper.ApiClient, null);
        }

        [TestMethod]
        public void TestApiHelper2()
        {
            ApiHelper.InitializeClient();

            Assert.AreNotEqual(null, ApiHelper.ApiClient);
        }

        [TestMethod]
        public void TestApiHelper3()
        {
            using (ApiHelper.ApiClient)
            {
                ApiHelper.InitializeClient();
                Assert.AreEqual(ApiHelper.ApiClient.BaseAddress, new Uri("http://54.162.248.95:4000"));
            }
        }

        [TestMethod]
        public void TestApiHelper4()
        {
            HttpClient tester = new HttpClient();
            tester.BaseAddress = new Uri("http://version1.api.memegenerator.net/");
            HttpClient other = ApiHelper.ApiClient;
            ApiHelper.ApiClient = tester;
            Assert.AreNotEqual(ApiHelper.ApiClient, other);
            Assert.AreEqual(tester, ApiHelper.ApiClient);
        }

        [TestMethod]
        public void TestAccountInfoModel1()
        {
            AccountInfoModel test = new AccountInfoModel();
            test.username = "";
            test.password = "";
            test.phone_number = "";

            Assert.AreEqual(test.username, "");
            Assert.AreEqual(test.password.Length, 0);
            Assert.AreEqual(test.phone_number.Length, 0);

        }

        [TestMethod]
        public void TestClipboardContentsModel1()
        {
            ClipboardContentsModel clipboardContents =
                new ClipboardContentsModel();
            clipboardContents.board_id = -1;
            clipboardContents.id = -1;
            clipboardContents.text_content = "";

            Assert.AreEqual(clipboardContents.board_id, -1);
            Assert.AreEqual(clipboardContents.id, -1);
            Assert.AreEqual(clipboardContents.text_content.Length, 0);
        }

        [TestMethod]
        public void TestClipboardModel1()
        {
            ClipboardModel board = new ClipboardModel();
            board.board_name = "";
            board.id = -1;

            Assert.AreEqual(board.board_name.Length, 0);
            Assert.AreEqual(board.id, -1);
        }

        [TestMethod]
        public void TestCreateAccountModel1()
        {
            CreateAccountModel model = new CreateAccountModel();
            Assert.IsNull(model.username);
            Assert.IsNull(model.password);
            Assert.IsNull(model.phone_number);

        }

        [TestMethod]
        public void TestCreateAccountModel2()
        {
            CreateAccountModel model = new CreateAccountModel();

            model.username = "";
            model.password = "";
            model.phone_number = "";

            Assert.IsNotNull(model.username);
            Assert.IsNotNull(model.password);
            Assert.IsNotNull(model.phone_number);

        }

        [TestMethod]
        public void TestNewClipboardItem1()
        {
            NewClipboardItemModel model = new NewClipboardItemModel();
            model.board_item = "";

            Assert.AreEqual(model.board_item, "");

        }

        [TestMethod]
        public void TestSimpleLoginPostModel1()
        {
            SimpleLoginPostModel model = new SimpleLoginPostModel();
            Assert.IsNull(model.username);
        }

        [TestMethod]
        public void TestSimpleLoginPostModel2()
        {
            SimpleLoginPostModel model = new SimpleLoginPostModel();
            model.username = "";
            Assert.AreEqual(model.username, "");
        }

        [TestMethod]
        public void TestUserLoginInfoModel1()
        {
            UserLoginInfoModel model = new UserLoginInfoModel();
            Assert.IsNull(model.username);
            Assert.IsNull(model.inserted_at);
            Assert.AreEqual(model.id, -1);
        }

        [TestMethod]
        public void TestUserLoginInfoModel2()
        {
            UserLoginInfoModel model = new UserLoginInfoModel();
            model.id = 0;
            model.inserted_at = "x";
            model.username = "y";

            Assert.AreEqual(model.id, 0);
            Assert.AreEqual(model.inserted_at, "x");
            Assert.AreEqual(model.username, "y");
        }
    }
}

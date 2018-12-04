using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clippy;
using System.Collections.Generic;
using System.Net.Http;

namespace ClippyTests
{
    [TestClass]
    public class ClippyTest
    {
        [TestMethod]
        public void TestCurrentUserCtor1()
        {
            UserLoginInfoModel login = new UserLoginInfoModel();
            login.ID = 1;
            login.Phone_number = "123-456-7899";
            login.Username = "Jane@doe.scam";

            CurrentUser user = new CurrentUser(login);

            Assert.AreEqual(user.GetUserId(), login.ID);
            Assert.AreEqual(user.GetPhoneNumber(), login.Phone_number);
            Assert.AreEqual(user.GetUsername(), login.Username);
        }

        [TestMethod]
        public void TestCurrentUserCtor2()
        {
            UserLoginInfoModel login = new UserLoginInfoModel();
            login.ID = -1;
            login.Phone_number = null;
            login.Username = "Jane@doe.scam";

            CurrentUser user = new CurrentUser(login);

            Assert.AreEqual(user.GetUserId(), login.ID);
            Assert.AreEqual(user.GetPhoneNumber(), null);
            Assert.AreEqual(user.GetUsername(), login.Username);
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
            login.ID = 1;
            login.Phone_number = "123-456-7899";
            login.Username = "Jane@doe.scam";

            CurrentUser user = new CurrentUser(login);
            user.SetClipboards(clipboards);
            String test = "iiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii";
            Assert.AreEqual(user.GetBoardId("iiiii"), 5);
            Assert.AreEqual(user.GetBoardId(test),test.Length);
            Assert.AreEqual(user.GetBoardId(""), -1);
            Assert.AreEqual(user.GetBoardId("iabcd"), -1);
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
            if (ApiHelper.ApiClient == null)
            {
                ApiHelper.InitializeClient();
            }
            Assert.AreEqual(ApiHelper.ApiClient.BaseAddress, new Uri("http://34.224.86.78:8080/"));
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
    }
}

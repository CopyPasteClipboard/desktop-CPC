using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clippy.ApiClasses
{
    /// <summary>
    /// Model class for updating an account's information. Used primarily in AccountView.xaml.cs
    /// </summary>
    public class AccountInfoModel
    {
        public string username;
        public string password;
        public string phone_number;
    }
}

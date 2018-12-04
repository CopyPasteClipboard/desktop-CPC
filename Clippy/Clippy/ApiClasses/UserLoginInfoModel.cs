using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clippy
{
    /// <summary>
    /// Class representing the returned data from logging in.
    /// </summary>
    public class UserLoginInfoModel
    {
        public int id { get; set; } = -1;
        public string username { get; set; } = null;
        public string inserted_at { get; set; } = null;
    }
}

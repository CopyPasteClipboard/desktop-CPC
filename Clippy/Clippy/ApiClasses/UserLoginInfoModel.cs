using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clippy
{
    public class UserLoginInfoModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Phone_number { get; set; } = null;
    }
}

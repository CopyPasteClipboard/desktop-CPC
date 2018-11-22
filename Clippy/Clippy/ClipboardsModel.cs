using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clippy
{
    public class ClipboardsModel
    {
        public string[] clipboards { get; set; }

        public static bool operator == (ClipboardsModel lhs, ClipboardsModel rhs)
        {
            return false;
        }
        public static bool operator != (ClipboardsModel lhs, ClipboardsModel rhs)
        {
            return !(lhs == rhs);
        }
        public static bool Equals(ClipboardsModel lhs, ClipboardsModel rhs)
        {
            return (lhs == rhs);
        }

    }

   

}

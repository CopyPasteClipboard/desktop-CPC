using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clippy
{
    public class ClipboardsModel
    {
        public string[] clipboards { get; set; } = new string[0];

        public List<String> GetClipboardNames()
        {
            List<String> ret = new List<String>();
            if (clipboards.Count() != 0)
            {
                foreach (string board in clipboards)
                {
                    ret.Add(board);
                }
            }
            return ret;
        }

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

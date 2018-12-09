using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clippy.ApiClasses
{
    public class NewClipboardModel
    {
        public int user_id { get; set; } = -1;
        public string board_name { get; set; } = null;
    }
}

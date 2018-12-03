using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clippy
{
    public class ClipboardContentsModel
    {
        public int id { get; set; }
        public int board_id { get; set; }
        public string text_content { get; set; }
    }
}

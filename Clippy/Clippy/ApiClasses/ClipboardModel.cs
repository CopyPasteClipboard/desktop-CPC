using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clippy
{
    /// <summary>
    /// Model class representing a single clipboard. Primarily called from HomeScreen
    /// </summary>
    public class ClipboardModel
    {
        public int id { get; set; }
        public string board_name { get; set; }
    }
}

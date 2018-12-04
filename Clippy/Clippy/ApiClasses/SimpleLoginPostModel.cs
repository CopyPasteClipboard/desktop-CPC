using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clippy.ApiClasses
{
    /// <summary>
    /// Class used as a simple API login call, passing only the username
    /// </summary>
    public class SimpleLoginPostModel
    {
        public string username { get; set; } = null;
    }
}

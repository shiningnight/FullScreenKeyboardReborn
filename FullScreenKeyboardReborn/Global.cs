using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FullScreenKeyboardReborn
{
    public static class Global
    {
        public static readonly Dictionary<Keys, string> DefaultKeyNames = new Dictionary<Keys, string>() {
            { Keys.Enter, "Enter" },
        };
    }
}

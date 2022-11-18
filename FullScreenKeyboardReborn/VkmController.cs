using System.Windows.Forms;

namespace FullScreenKeyboardReborn
{
    internal interface VkmController
    {
        int Key(Keys vkCode, int flag);
    }
}

using System.IO;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using static FullScreenKeyboardReborn.VirtualKey;

namespace FullScreenKeyboardReborn
{
    internal class Settings
    {
        public int HoldDelay = 180;
        public int RepeatInterval = 32;
        public int PressDelay = 180;
        public int ActionDelay = 16;
        public string LayoutName = "Standard.txt";
        public ActionMode ActionModeLeft = ActionMode.Hold;
        public ActionMode ActionModeRight = ActionMode.Repeat;
        public ActionMode ActionModeWheel = ActionMode.RepeatLock;
        public ActionMode ActionModeWheelDown = ActionMode.HoldLock;
        public ActionMode ActionModeWheelUp = ActionMode.RepeatLock;
        public Keys CubeUp = Keys.Up;
        public Keys CubeDown = Keys.Down;
        public Keys CubeLeft = Keys.Left;
        public Keys CubeRight = Keys.Right;
        public Keys CubeActionLeft = Keys.Z;
        public Keys CubeActionRight = Keys.X;
        public Keys CubeActionWheel = Keys.C;
        public Keys CubeActionWheelDown = Keys.Q;
        public Keys CubeActionWheelUp = Keys.E;

        public static Settings Load() {
            Settings settings = new Settings();
            if (!File.Exists("Settings.json"))
            {
                Save(settings);
            }
            else
            {
                using (var reader = new StreamReader("Settings.json", Encoding.UTF8))
                {
                   settings = JsonConvert.DeserializeObject<Settings>(reader.ReadToEnd());
                }
            }
            return settings;
            
        }
        public static void Save(Settings settings) { 
            using (var writer = new StreamWriter("Settings.json", false))
                {
                    writer.Write(JsonConvert.SerializeObject(settings));
                }
        }
    }
}
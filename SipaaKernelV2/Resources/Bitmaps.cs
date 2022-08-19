using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SipaaKernelV2.Core;
namespace SipaaKernelV2
{
    internal class Bitmaps
    {
        public static Bitmap cursor = new Bitmap(Files.Cursor);
        public static Bitmap wallpaper = new Bitmap(Files.Wallpaper);
        public static Bitmap wallpaperStretched = new Bitmap(Files.Wallpaper);
        public static Bitmap logo = new Bitmap(Files.OSLogo);
        public static Bitmap logolight = new Bitmap(Files.OSLogoLight);
        public static Bitmap checkbox = new Bitmap(Files.CheckBox);
        public static Bitmap checkedcheckbox = new Bitmap(Files.CheckedCheckBox);
        public static Bitmap error = new Bitmap(Files.Error);
        public static Bitmap file = new Bitmap(Files.File);
        public static Bitmap folder = new Bitmap(Files.Folder);
        public static Bitmap about = new Bitmap(Files.AboutOS);
        public static Bitmap sipad = new Bitmap(Files.Sipad);
        public static Bitmap uilib = new Bitmap(Files.UILibrary);
        public static Bitmap ssd = new Bitmap(Files.SSD);
        public static Bitmap throwex = new Bitmap(Files.ThrowException);
        public static Bitmap shutdown = new Bitmap(Files.Shutdown);
        public static Bitmap reboot = new Bitmap(Files.Reboot);
        public static Bitmap consolemode = new Bitmap(Files.ConsoleMode);
        public static Bitmap settings = new Bitmap(Files.Settings);
    }
}

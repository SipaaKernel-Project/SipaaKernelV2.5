using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.Graphics;
using SipaaKernelV2.Core;
using SipaaKernelV2.UI.SysTheme;

namespace SipaaKernelV2.Applications
{
    internal class BootApp : Application
    {
        public BootApp()
        {
            ApplicationName = "Boot Screen App";
            ApplicationDeveloper = "RaphMar2019";
            ApplicationVersion = 1.0;
        }
        public override void Update()
        {
        }
        public override void Draw(Canvas c)
        {
            c.DrawFilledRectangle(new Pen(ThemeManager.GetCurrentTheme().AppBackColor), 0, 0, (int)Kernel.ScreenWidth, (int)Kernel.ScreenHeight);
            c.DrawImage(Bitmaps.logo, (int)Kernel.ScreenWidth / 2 - (int)Bitmaps.logo.Width / 2, (int)Kernel.ScreenHeight / 2 - (int)Bitmaps.logo.Height / 2);
            int swidth = "Booting up...".Length * Kernel.font.Width;
            c.DrawString("Booting up...", Kernel.font, new Pen(ThemeManager.GetCurrentTheme().ForeColor), (int)Kernel.ScreenWidth / 2 - swidth / 2, (int)Kernel.ScreenHeight / 2 - (int)Bitmaps.logo.Height / 2 + (int)Bitmaps.logo.Height + 10);
        }
    }
}

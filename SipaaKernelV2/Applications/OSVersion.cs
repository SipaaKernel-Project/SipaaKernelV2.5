using Cosmos.System.Graphics;
using SipaaKernelV2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SipaaKernelV2.UI.SysTheme;

namespace SipaaKernelV2.Applications
{
    internal class OSVersion : Application
    {
        public OSVersion()
        {
            ApplicationName = "SipaaKernel Version App";
            ApplicationDeveloper = "RaphMar2019";
            ApplicationVersion = 1.0;
            AppIcon = Bitmaps.about;
        }
        public override void Update()
        {
            base.Update();
        }
        public override void Draw(Canvas c)
        {
            base.Draw(c);
            if (ThemeManager.GetCurrentTheme().ThemeId == 1)
                c.DrawImage(Bitmaps.logolight, 8, 40);
            else
                c.DrawImage(Bitmaps.logo, 8, 40);
            c.DrawString(Kernel.OSName, Kernel.font, new Pen(ThemeManager.GetCurrentTheme().ForeColor), 10, 40 + (int)Bitmaps.logo.Height + 15);
            c.DrawString("Version " + Kernel.OSVersion + " (build " + Kernel.OSBuild + ")", Kernel.font, new Pen(ThemeManager.GetCurrentTheme().ForeColor), 10, 40 + (int)Bitmaps.logo.Height + 30);
            c.DrawString("Made with <3 by RaphMar2019", Kernel.font, new Pen(ThemeManager.GetCurrentTheme().ForeColor), 10, 40 + (int)Bitmaps.logo.Height + 45);
            c.DrawString("Special thanks to the Cosmos team (Without Cosmos, this OS isn't possible!)", Kernel.font, new Pen(ThemeManager.GetCurrentTheme().ForeColor), 10, 40 + (int)Bitmaps.logo.Height + 60);
            c.DrawString("Thanks to xyve#5469 for the text editor idea,", Kernel.font, new Pen(ThemeManager.GetCurrentTheme().ForeColor), 10, 40 + (int)Bitmaps.logo.Height + 60 + Kernel.font.Height + 6);
            c.DrawString("Kokolor#5434 for File Explorer, Boot Screen!", Kernel.font, new Pen(ThemeManager.GetCurrentTheme().ForeColor), 10, 40 + (int)Bitmaps.logo.Height + 60 + Kernel.font.Height * 2 + 6);
        }
    }
}

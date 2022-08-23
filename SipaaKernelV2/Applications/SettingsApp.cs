using SipaaKernelV2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SipaaKernelV2.UI;
using SipaaKernelV2.UI.SysTheme;
using Cosmos.System.Graphics;
using Cosmos.System;
using SipaaKernelV2.UI.SysTheme.Themes;
using static SipaaKernelV2.Kernel;
namespace SipaaKernelV2.Applications
{
    public class SettingsApp : Application
    {
        Button btn1080p, btn1024x768, btn720p, btnLight, btnDark;

        public SettingsApp()
        {
            this.ApplicationName = "Settings";
            this.ApplicationDeveloper = "RaphMar2019";
            this.ApplicationVersion = 1.0;
            this.AppIcon = Bitmaps.settings;
            btn1024x768 = new Button("1024x768", 4, (uint)TitleBarHeight + 10 + (uint)Kernel.font.Height * 2);
            btn720p = new Button("1280x720", 8 + 150, (uint)TitleBarHeight + 10 + (uint)Kernel.font.Height * 2);
            btn1080p = new Button("1920x1080", 12 + 300, (uint)TitleBarHeight + 10 + (uint)Kernel.font.Height * 2);
            btnLight = new Button("Light", 4, (uint)TitleBarHeight + 46 + (uint)Kernel.font.Height * 3 + 4);
            btnDark = new Button("Dark", 158, (uint)TitleBarHeight + 46 +(uint) Kernel.font.Height * 3 + 4);
        }
        public override void Draw(Canvas c)
        {
            base.Draw(c);
            c.DrawString("Set display resolution (current is " + Kernel.ScreenWidth + "x" + Kernel.ScreenHeight + ") :", Kernel.font, new Pen(ThemeManager.GetCurrentTheme().ForeColor), 4, TitleBarHeight + 4);
            c.DrawString("To have more resolutions choices, go to console mode.", Kernel.font, new Pen(ThemeManager.GetCurrentTheme().ForeColor), 4, TitleBarHeight + 6 + Kernel.font.Height);
            c.DrawString("Set your theme (current is " + ThemeManager.GetCurrentTheme().ThemeName + ") : ", Kernel.font, new Pen(ThemeManager.GetCurrentTheme().ForeColor), 4, TitleBarHeight + 46 + Kernel.font.Height * 2 + 4);
            btn1024x768.Draw(c);
            btn720p.Draw(c);
            btn1080p.Draw(c);
            btnLight.Draw(c);
            btnDark.Draw(c);
        }
        private void SetResolution(uint width, uint height)
        {
            Kernel.ScreenWidth = width;
            Kernel.ScreenHeight = height;
            Kernel.c.Mode = new Mode((int)width, (int)height, ColorDepth.ColorDepth32);
            MouseManager.ScreenWidth = width;
            MouseManager.ScreenHeight = height;
            SkOpenApp(new SipaaDesktop());
        }
        public override void Update()
        {
            base.Update();
            btn1024x768.Update();
            btn1080p.Update();
            btn720p.Update();
            btnLight.Update();
            btnDark.Update();
            if (btnLight.ButtonState == ButtonState.Clicked)
            {
                ThemeManager.SetCurrentTheme(new Light());
                SkOpenApp(new SipaaDesktop());
            }
            if (btnDark.ButtonState == ButtonState.Clicked)
            {
                ThemeManager.SetCurrentTheme(new Dark());
                SkOpenApp(new SipaaDesktop());
            }
            if (btn1024x768.ButtonState == ButtonState.Clicked)
            {
                SetResolution(1024, 768);
            }
            if (btn720p.ButtonState == ButtonState.Clicked)
            {
                SetResolution(1280, 720);
            }
            if (btn1080p.ButtonState == ButtonState.Clicked)
            {
                SetResolution(1920, 1080);
            }
        }
    }
}

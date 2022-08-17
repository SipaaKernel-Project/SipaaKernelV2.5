using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.Graphics;
using SipaaKernelV2.Applications;
using SipaaKernelV2.UI;
using SipaaKernelV2.UI.SysTheme;

namespace SipaaKernelV2.Core
{
    internal class Application
    {
        public string ApplicationName, ApplicationDeveloper;
        public Bitmap AppIcon;
        public double ApplicationVersion;
        private Button closeButton;
        public const int TitleBarHeight = 32;
        public Application()
        {
            closeButton = new Button("X", Kernel.ScreenWidth - 24, 0, 24, 32);
        }
        public virtual void Update()
        {
            closeButton.Update();
            if (closeButton.ButtonState == ButtonState.Clicked) { Kernel.OpenApplication(new SipaaDesktop()); }
        }
        public virtual void Draw(Canvas c)
        {
            c.DrawFilledRectangle(new Pen(ThemeManager.GetCurrentTheme().AppBackColor), 0, 0, (int)Kernel.ScreenWidth, (int)Kernel.ScreenHeight);
            c.DrawFilledRectangle(new Pen(ThemeManager.GetCurrentTheme().BackColor), 0, 0, (int)Kernel.ScreenWidth, 32);
            if (AppIcon != null)
            {
                c.DrawString(ApplicationName, Kernel.font, new Pen(ThemeManager.GetCurrentTheme().ForeColor), 24 + 9, 10);
                c.DrawImageAlpha(AppIcon, 4, 32 / 2 - (int)Bitmaps.about.Width / 2); 
            }
            else
            {
                c.DrawString(ApplicationName, Kernel.font, new Pen(ThemeManager.GetCurrentTheme().ForeColor), 24 + 9, 10);
            }
            closeButton.Draw(c);
        }
    }
}

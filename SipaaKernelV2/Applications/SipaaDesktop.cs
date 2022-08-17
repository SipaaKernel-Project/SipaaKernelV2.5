using Cosmos.HAL;
using Cosmos.System.Graphics;
using SipaaKernelV2.Core;
using SipaaKernelV2.UI;
using SipaaKernelV2.UI.SysTheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.Applications
{
    internal class SipaaDesktop : Application
    {
        Button openOSVersion, openUILibrary, openSipad, openFileExplorer, shutdown, consolemode, reboot, exButton;

        public SipaaDesktop()
        {
            ApplicationName = "SipaaDesktop";
            ApplicationDeveloper = "RaphMar2019";
            ApplicationVersion = 1.0;
            shutdown = new Button("", Kernel.ScreenWidth - 120, Kernel.ScreenHeight - 40, 40, 40);
            reboot = new Button("", Kernel.ScreenWidth - 160, Kernel.ScreenHeight - 40, 40, 40);
            consolemode = new Button("", Kernel.ScreenWidth - 200, Kernel.ScreenHeight - 40, 40, 40);
            exButton = new Button("", Kernel.ScreenWidth - 240, Kernel.ScreenHeight - 40, 40, 40);

            openOSVersion = new Button("", 80, Kernel.ScreenHeight - 40, 40, 40);
            openUILibrary = new Button("", 120, Kernel.ScreenHeight - 40, 40, 40);
            openSipad = new Button("", 160, Kernel.ScreenHeight - 40, 40, 40);
            openFileExplorer = new Button("", 200, Kernel.ScreenHeight - 40, 40, 40);

            shutdown.Bitmap = Bitmaps.shutdown;
            reboot.Bitmap = Bitmaps.reboot;
            exButton.Bitmap = Bitmaps.throwex;
            consolemode.Bitmap = Bitmaps.consolemode;

            openOSVersion.Bitmap = Bitmaps.about;
            openUILibrary.Bitmap = Bitmaps.uilib;
            openSipad.Bitmap = Bitmaps.sipad;
            openFileExplorer.Bitmap = Bitmaps.folder;
        }
        public override void Draw(Canvas c)
        {
            c.DrawImage(Bitmaps.wallpaper, 0, 0);
            c.DrawFilledRectangle(new Pen(ThemeManager.GetCurrentTheme().BackColor), 0, 0, (int)Kernel.ScreenWidth, 24);
            c.DrawString("SipaaKernel V2.5 - Desktop", Kernel.font, new Pen(ThemeManager.GetCurrentTheme().ForeColor), 4, 4);
            int timeWidth = (RTC.Year + "/" + RTC.Month + "/" + RTC.DayOfTheMonth + " " + RTC.Hour + ":" + RTC.Minute).Length * Kernel.font.Width;
            c.DrawString(RTC.Year + "/" + RTC.Month + "/" + RTC.DayOfTheMonth + " " + RTC.Hour + ":" + RTC.Minute, Kernel.font, new Pen(ThemeManager.GetCurrentTheme().ForeColor), (int)Kernel.ScreenWidth / 2 - timeWidth / 2, 4);
            // draw dock
            c.DrawFilledRectangle(new Pen(ThemeManager.GetCurrentTheme().BackColor), 80, (int)Kernel.ScreenHeight - 40, (int)Kernel.ScreenWidth - (80 * 2), 40);
            //desktopTextView.Draw(c);
            openOSVersion.Draw(c);
            shutdown.Draw(c);
            reboot.Draw(c);
            consolemode.Draw(c);
            openUILibrary.Draw(c);
            openSipad.Draw(c);
            openFileExplorer.Draw(c);
            //window.Draw(c);
            exButton.Draw(c);
        }
        public override void Update()
        {
            openOSVersion.Update();
            openUILibrary.Update();
            shutdown.Update();
            reboot.Update();
            consolemode.Update();
            openSipad.Update();
            openFileExplorer.Update();
            //window.Update();
            exButton.Update();
            if (openOSVersion.ButtonState == ButtonState.Clicked)
            {
                Kernel.OpenApplication(new OSVersion());
            }
            if (openSipad.ButtonState == ButtonState.Clicked)
            {
                Kernel.OpenApplication(new Sipad());
            }
            if (openUILibrary.ButtonState == ButtonState.Clicked)
            {
                Kernel.OpenApplication(new UIGallery());
            }
            if (shutdown.ButtonState == ButtonState.Clicked)
            {
                Cosmos.System.Power.Shutdown();
            }
            if (reboot.ButtonState == ButtonState.Clicked)
            {
                Cosmos.System.Power.Reboot();
            }
            if (openFileExplorer.ButtonState == ButtonState.Clicked)
            {
                Kernel.OpenApplication(new FileExplorer());
            }
            if (consolemode.ButtonState == ButtonState.Clicked)
            {
                Kernel.ConsoleMode();
                Shell.GetInput();
                return;
            }
            if (exButton.ButtonState == ButtonState.Clicked)
            {
                throw new Exception("UserException");
                return;
            }
        }
    }
}

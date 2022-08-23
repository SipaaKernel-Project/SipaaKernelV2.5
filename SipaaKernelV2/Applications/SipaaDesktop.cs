using Cosmos.HAL;
using Cosmos.System.Graphics;
using SipaaKernelV2.Core;
using SipaaKernelV2.UI;
using SipaaKernelV2.UI.Extensions;
using SipaaKernelV2.UI.SysTheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SipaaKernelV2.Kernel;

namespace SipaaKernelV2.Applications
{
    public class SipaaDesktop : Application
    {
        Button openOSVersion, openUILibrary, openSipad, openFileExplorer,openSettings, shutdown, consolemode, reboot, exButton;

        public SipaaDesktop()
        {
            ApplicationName = "SipaaDesktop";
            ApplicationDeveloper = "RaphMar2019";
            ApplicationVersion = 1.0;
            shutdown = new Button("", Kernel.ScreenWidth - 160, Kernel.ScreenHeight - 48, 40, 40);
            reboot = new Button("", Kernel.ScreenWidth - 200, Kernel.ScreenHeight - 48, 40, 40);
            consolemode = new Button("", Kernel.ScreenWidth - 240, Kernel.ScreenHeight - 48, 40, 40);
            exButton = new Button("", Kernel.ScreenWidth - 280, Kernel.ScreenHeight - 48, 40, 40);

            openOSVersion = new Button("", 120, Kernel.ScreenHeight - 48, 40, 40);
            openUILibrary = new Button("", 160, Kernel.ScreenHeight - 48, 40, 40);
            openSipad = new Button("", 200, Kernel.ScreenHeight - 48, 40, 40);
            openFileExplorer = new Button("", 240, Kernel.ScreenHeight - 48, 40, 40);
            openSettings = new Button("", 280, Kernel.ScreenHeight - 48, 40, 40);

            shutdown.Bitmap = Bitmaps.shutdown;
            reboot.Bitmap = Bitmaps.reboot;
            exButton.Bitmap = Bitmaps.throwex;
            consolemode.Bitmap = Bitmaps.consolemode;

            openOSVersion.Bitmap = Bitmaps.about;
            openUILibrary.Bitmap = Bitmaps.uilib;
            openSipad.Bitmap = Bitmaps.sipad;
            openFileExplorer.Bitmap = Bitmaps.folder;
            openSettings.Bitmap = Bitmaps.settings;
        }
        public override void Draw(Canvas c)
        {
            int timeWidth = (RTC.Year + "/" + RTC.Month + "/" + RTC.DayOfTheMonth + " " + RTC.Hour + ":" + RTC.Minute).Length * Kernel.font.Width;
            c.DrawImage(Bitmaps.wallpaper, 0, 0);
            //c.DrawFilledRectangle(new Pen(ThemeManager.GetCurrentTheme().BackColor), 0, 0, (int)Kernel.ScreenWidth, 24);
            c.DrawRoundRect(new Pen(ThemeManager.GetCurrentTheme().BackColor), 4, 4, 225, 16, 4);
            c.DrawRoundRect(new Pen(ThemeManager.GetCurrentTheme().BackColor), (int)Kernel.ScreenWidth / 2 - 250 / 2, 4, 250, 16, 4);
            c.DrawString(Kernel.OSName + " - " + Kernel.language.desktop, Kernel.font, new Pen(ThemeManager.GetCurrentTheme().ForeColor), 4, 4);
            c.DrawString(RTC.Year + "/" + RTC.Month + "/" + RTC.DayOfTheMonth + " " + RTC.Hour + ":" + RTC.Minute, Kernel.font, new Pen(ThemeManager.GetCurrentTheme().ForeColor), (int)Kernel.ScreenWidth / 2 - timeWidth / 2, 4);
            // draw dock
            c.DrawRoundRect(new Pen(ThemeManager.GetCurrentTheme().BackColor), 120, (int)Kernel.ScreenHeight - 48, (int)Kernel.ScreenWidth - (120 * 2), 40, 11);
            //desktopTextView.Draw(c);
            openOSVersion.Draw(c);
            shutdown.Draw(c);
            reboot.Draw(c);
            consolemode.Draw(c);
            openUILibrary.Draw(c);
            openSipad.Draw(c);
            openFileExplorer.Draw(c);
            openSettings.Draw(c);
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
            openSettings.Update();
            //window.Update();
            exButton.Update();
            if (openOSVersion.ButtonState == ButtonState.Clicked)
            {
                SkOpenApp(new OSVersion());
            }
            if (openSipad.ButtonState == ButtonState.Clicked)
            {
                SkOpenApp(new Sipad());
            }
            if (openUILibrary.ButtonState == ButtonState.Clicked)
            {
                SkOpenApp(new UIGallery());
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
                SkOpenApp(new FileExplorer());
            }
            if (openSettings.ButtonState == ButtonState.Clicked)
            {
                SkOpenApp(new SettingsApp());
            }
            if (consolemode.ButtonState == ButtonState.Clicked)
            {
                SkRaiseHardError("User manually throwed this exception.");
                Shell.GetInput();
                return;
            }
            if (exButton.ButtonState == ButtonState.Clicked)
            {
                throw new Exception("UserException");
            }
        }
    }
}

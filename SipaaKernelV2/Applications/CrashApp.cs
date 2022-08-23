using Cosmos.System.Graphics;
using SipaaKernelV2.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.Applications
{
    public class CrashApp : Application
    {
        Exception ex;
        public CrashApp(Exception ex)
        {
            ApplicationName = "SipaaKernel crash screen application";
            ApplicationDeveloper = "RaphMar2019";
            ApplicationVersion = 1.0;
            this.ex = ex;
        }
        private int GetFontWidth(string text)
        {
            return text.Length * Kernel.font.Width;
        }
        public override void Draw(Canvas c)
        {
            int errorX = (int)Kernel.ScreenWidth / 2 - (int)Bitmaps.error.Width / 2;
            int problemX = (int)Kernel.ScreenWidth / 2 - GetFontWidth(Kernel.language.guiDeviceRanIntoAProblem) / 2;
            int sorryX = (int)Kernel.ScreenWidth / 2 - GetFontWidth(Kernel.language.guiSorryForException) / 2;
            int reportX = (int)Kernel.ScreenWidth / 2 - GetFontWidth(Kernel.language.guiReportToSipaaKernelDiscord) / 2;
            int exceptionInfoX = (int)Kernel.ScreenWidth / 2 - GetFontWidth("Exception message : " + ex.Message) / 2;
            c.DrawFilledRectangle(new Pen(Color.FromArgb(237, 28, 36)), 0, 0, (int)Kernel.ScreenWidth, (int)Kernel.ScreenHeight);
            c.DrawImage(Bitmaps.error, errorX, 40);
            c.DrawString(Kernel.language.guiDeviceRanIntoAProblem, Kernel.font, new Pen(Color.White), problemX, 40 + (int)Bitmaps.error.Height + 15);
            c.DrawString(Kernel.language.guiSorryForException, Kernel.font, new Pen(Color.White), sorryX, 40 + (int)Bitmaps.logo.Height + 30);
            c.DrawString(Kernel.language.guiReportToSipaaKernelDiscord, Kernel.font, new Pen(Color.White), reportX, 40 + (int)Bitmaps.logo.Height + 45);
            c.DrawString("Exception message : " + ex.Message, Kernel.font, new Pen(Color.White), exceptionInfoX, (int)Kernel.ScreenHeight - 10 - Kernel.font.Height);
        }
        public override void Update()
        {
        }
    }
}

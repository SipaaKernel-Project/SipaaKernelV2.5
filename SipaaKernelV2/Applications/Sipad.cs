using Cosmos.System.Graphics;
using SipaaKernelV2.Core;
using SipaaKernelV2.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.Applications
{
    public class Sipad : Application
    {
        TextBox tbDoc;
        public Sipad()
        {
            ApplicationName = "Sipad App";
            ApplicationDeveloper = "RaphMar2019";
            ApplicationVersion = 1.0;
            AppIcon = Bitmaps.sipad;
            tbDoc = new TextBox(4, TitleBarHeight + 4);
            tbDoc.Focus = false;
            tbDoc.Multiline = true;
            tbDoc.Width = Kernel.ScreenWidth - (4 * 2);
            tbDoc.Height = Kernel.ScreenHeight - (4 * 2);
        }

        public override void Update()
        {
            base.Update();
            tbDoc.Update();
        }

        public override void Draw(Canvas c)
        {
            base.Draw(c);
            tbDoc.Draw(c);
        }
    }
}

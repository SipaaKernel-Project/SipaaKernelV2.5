using System;
using System.Collections.Generic;
using Color = System.Drawing.Color;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.Graphics;

namespace SipaaKernelV2.UI
{
    public class ColorPens
    {
        public static Pen
            whitePen = new Pen(Color.White),
            lightGrayPen = new Pen(Color.LightGray),
            blackPen = new Pen(Color.Black),
            idleButtonPen = new Pen(Color.FromArgb(32, 32, 32)),
            hoverButtonPen = new Pen(Color.FromArgb(64, 64, 64)),
            clickedButtonPen = new Pen(Color.FromArgb(12, 12, 12));
    }
}

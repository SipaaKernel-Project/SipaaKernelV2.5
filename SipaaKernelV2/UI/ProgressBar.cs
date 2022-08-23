using Cosmos.System.Graphics;
using SipaaKernelV2.UI.Extensions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.UI
{
    public class ProgressBar : Control
    {
        private uint width = 150, height = 150, value = 0;
        private SysTheme.ThemeBase theme = SysTheme.ThemeManager.GetCurrentTheme();
        private uint borderradius = 11;

        public uint BorderRadius { get { return borderradius; } set { borderradius = value; } }
        public uint Width { get { return width; } set { width = value; } }
        public uint Height { get { return height; } set { height = value; } }

        public uint Value { get => value; set => this.value = value; }

        public ProgressBar(uint x, uint y, uint width, uint height)
        {
            this.X = x;
            this.Y = y;
            this.width = width;
            this.height = height;
        }

        public override void Draw(Canvas c)
        {
            if (borderradius >= 1)
            {
                c.DrawRoundRect(new Pen(theme.BackColor), (int)X, (int)Y, (int)width, (int)height, (int)borderradius);
                if (value > 0)
                    c.DrawRoundRect(new Pen(Color.Green), (int)X, (int)Y, (int)X + (int)Width / (int)Value, (int)Height, (int)borderradius);
            }
            else
            {
                c.DrawFilledRectangle(new Pen(theme.BackColor), (int)X, (int)Y, (int)width, (int)height);
                if (value > 0)
                    c.DrawFilledRectangle(new Pen(Color.Green), (int)X, (int)Y, (int)X + (int)Width / (int)Value, (int)Height);
            }

            if (theme.BorderSize > 1)
                c.DrawRectangle(new Pen(theme.BorderColor, theme.BorderSize), (int)X, (int)Y, (int)width, (int)height);
            c.DrawString(value + "%", Kernel.font, new Pen(theme.ForeColor), (int)Kernel.ScreenWidth / 2 - ((int)value + "%".Length) / 2, (int)this.Y + (int)this.Height / 2 - (int)Kernel.font.Height / 2);
        }

        public override void Update()
        {
            if (Value > 100)
                Value = 100;
            else if (Value < 0)
                Value = 0;
        }
    }
}

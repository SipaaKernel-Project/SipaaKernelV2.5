using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using SipaaKernelV2.UI.SysTheme;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.UI
{
    public class CheckBox : Control
    {
        private string text = "Check Box";
        private bool check;
        private ThemeBase theme = ThemeManager.GetCurrentTheme();

        public string Text { get { return text; } set { text = value; } }

        public bool Checked { get => check; set => check = value; }
        public ThemeBase Theme { get => theme; set => theme = value; }

        public CheckBox(string text, uint x, uint y)
        {
            this.text = text;
            this.X = x;
            this.Y = y;
        }

        public override void Draw(Canvas c)
        {
            switch (check)
            {
                case true:
                    c.DrawRectangle(new Pen(theme.BackColor), (int)X, (int)Y, 32, 32);
                    if (theme.BorderSize > 1)
                    {
                        c.DrawRectangle(new Pen(theme.BorderColor, theme.BorderSize), (int)X, (int)Y, 32, 32);
                    }
                    c.DrawLine(new Pen(theme.ForeColor, 2), (int)X + 4, (int)Y + 4, 32 - 4, 32 - 4);
                    c.DrawLine(new Pen(theme.ForeColor, 2), this.X + 32 - 4, 32 - 4, (int)X + 4, (int)Y + 4);
                    break;
                case false:
                    c.DrawRectangle(new Pen(theme.BackColor), (int)X, (int)Y, 32, 32);
                    if (theme.BorderSize > 1)
                    {
                        c.DrawRectangle(new Pen(theme.BorderColor, theme.BorderSize), (int)X, (int)Y, 32, 32);
                    }
                    break;
            }
            c.DrawString(Text, Kernel.font, new Pen(theme.ForeColor), (int)X + 36, (int)Y + 10);
        }

        public override void Update()
        {
            if (MouseManager.X > X && MouseManager.X < X + Bitmaps.checkbox.Width && MouseManager.Y > Y && MouseManager.Y < Y + Bitmaps.checkbox.Height && MouseManager.MouseState == MouseState.Left)
            {
                check = !check;
            }
        }
    }
}

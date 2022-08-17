using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SipaaKernelV2.UI.SysTheme;

namespace SipaaKernelV2.UI
{
    public class Button : Control
    {
        // Fields, properties and constructors
        private string text = "Button";
        private uint width = 150, height = 40;
        private ButtonState state;
        private ThemeBase theme = ThemeManager.GetCurrentTheme();
        private Bitmap bmp;

        public string Text { get { return text; } set { text = value; } }
        public uint Width { get { return width; } set { width = value; } }
        public uint Height { get { return height; } set { height = value; } }
        public ButtonState ButtonState { get { return state; } }
        public ThemeBase Theme { get { return theme; } set { theme = value; } }
        public Bitmap Bitmap { get { return bmp; } set { bmp = value; } }

        public Button(string text, uint x, uint y, uint width, uint height)
        {
            this.text = text;
            this.X = x;
            this.Y = y;
            this.width = width;
            this.height = height;
        }
        public Button(string text, uint x, uint y)
        {
            this.text = text;
            this.X = x;
            this.Y = y;
        }

        public override void Draw(Canvas c)
        {
            // Draw button rectangle 
            switch (this.state)
            {
                case ButtonState.Idle:
                    c.DrawFilledRectangle(new Pen(theme.BackColor), (int)X, (int)Y, (int)width, (int)height);
                    break;
                case ButtonState.Hover:
                    c.DrawFilledRectangle(new Pen(theme.HoveredBackColor), (int)X, (int)Y, (int)width, (int)height);
                    break;
                case ButtonState.Clicked:
                    c.DrawFilledRectangle(new Pen(theme.ClickedBackColor), (int)X, (int)Y, (int)width, (int)height);
                    break;
            }
            if (theme.BorderSize > 1)
            {
                c.DrawRectangle(new Pen(theme.BorderColor, theme.BorderSize), (int)X, (int)Y, (int)width, (int)height);
            }
            // Draw text & bitmap under the button
            int sx = (int) (X + (width / 2) - (text.Length * Kernel.font.Width / 2));
            c.DrawString(Text, Kernel.font, new Pen(theme.ForeColor), sx, (int)this.Y + (int)this.Height / 2 - (int)Kernel.font.Height / 2);
            if (bmp != null)
            {
                c.DrawImageAlpha(bmp, (int)X + 8, (int)this.Y + (int)this.Height / 2 - (int)bmp.Height / 2);
            }
        }

        public override void Update()
        {
            if (MouseManager.X > X && MouseManager.X < X + Width && MouseManager.Y > Y && MouseManager.Y < Y + Height)
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    state = ButtonState.Clicked;
                }
                else
                {
                    state = ButtonState.Hover;
                }
            }
            else
            {
                state = ButtonState.Idle;
            }
        }
    }
}

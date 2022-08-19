using Cosmos.System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using SipaaKernelV2.Core.Keyboard;
using SipaaKernelV2.UI.Extensions;
using SipaaKernelV2.UI.SysTheme;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.UI
{
    public class TextBox : Control
    {
        // Fields, properties and constructors
        private string text = "";
        private uint width = 150, height = 40;
        private bool focus = false;
        private bool multiline = false;
        private ThemeBase theme = ThemeManager.GetCurrentTheme();
        private KBStringReader r;
        private byte tick;
        private byte prevSec;
        private bool cursor;
        private bool passwordFilter;
        private int textW;
        private uint borderradius = 11;

        public uint BorderRadius { get { return borderradius; } set { borderradius = value; } }
        public string Text { get { return text; } }
        public bool Focus { get { return focus; } set { focus = value; } }
        public uint Width { get { return width; } set { width = value; } }
        public uint Height { get { return height; } set { height = value; } }
        public bool Multiline { get => multiline; set { multiline = value; r.acceptNewLine = value; } }
        public bool PasswordFilter { get => passwordFilter; set => passwordFilter = value; }
        public ThemeBase Theme { get { return theme; } set { theme = value; } }

        public TextBox(uint x, uint y)
        {
            r = new KBStringReader();
            this.X = x;
            this.Y = y;
        }

        public override void Draw(Canvas c)
        {
            if (borderradius >= 1)
                c.DrawRoundRect(new Pen(theme.BackColor), (int)X, (int)Y, (int)width, (int)height, (int)borderradius);
            else
                c.DrawFilledRectangle(new Pen(theme.BackColor), (int)X, (int)Y, (int)width, (int)height);

            if (theme.BorderSize > 1)
            {
                c.DrawRectangle(new Pen(theme.BorderColor, theme.BorderSize), (int)X, (int)Y, (int)width, (int)height);
            }
            if (text.Length > 0)
            {
                if (!passwordFilter && multiline)
                {
                    c.DrawString(text, Kernel.font, new Pen(theme.ForeColor), (int)X + 4, (int)Y + 4);
                }
                else if (!passwordFilter) 
                {
                    c.DrawString(text,Kernel.font, new Pen(theme.ForeColor), (int)X + 4, (int)Y + (int)height / 2 - (int)Kernel.font.Height / 2); 
                }
                else if (passwordFilter && multiline)
                {
                    int sx = (int)X + 4;
                    for (int i = 0; i < text.Length; i++)
                    {
                        c.DrawChar('*', Kernel.font, new Pen(theme.ForeColor), sx, (int)Y + 4);
                        sx += Kernel.font.Width;
                    }
                }
                else if (passwordFilter)
                {
                    int sx = (int)X + 4;
                    for (int i = 0; i < text.Length; i++)
                    {
                        c.DrawChar('*', Kernel.font, new Pen(theme.ForeColor), sx, (int)Y + (int)height / 2 - (int)Kernel.font.Height / 2);
                        sx += Kernel.font.Width;
                    }
                }
            }
            
        }

        public override void Update()
        {
            textW = text.Length * Kernel.font.Width;
            if (textW < 0) { textW = 0; }

            if (MouseManager.X > X && MouseManager.X < X + Width && MouseManager.Y > Y && MouseManager.Y < Y + Height)
            {
                if (MouseManager.MouseState == MouseState.Left)
                {
                    focus = true;
                }
            }


            // when focused
            if (focus)
            {
                if (KBPS2.IsKeyDown(ConsoleKeyEx.Escape)) { focus = false; }
                else
                {
                    tick = Cosmos.HAL.RTC.Second;
                    if (tick != prevSec)
                    {
                        cursor = !cursor;
                        prevSec = tick;
                    }
                    r.GetInput();
                    text = r.output;
                }
            }
        }
    }
}

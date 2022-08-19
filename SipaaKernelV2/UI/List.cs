using Cosmos.System.Graphics;
using SipaaKernelV2.UI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.UI
{
    public class List : Control
    {
        private uint width = 150, height = 225;
        private bool visible = false;
        private List<Button> buttons = new List<Button>();
        private SysTheme.ThemeBase theme = SysTheme.ThemeManager.GetCurrentTheme();
        private uint borderradius = 11;

        public uint BorderRadius { get { return borderradius; } set { borderradius = value; } }
        public List<Button> Buttons { get { return buttons; } set { buttons = value; } }
        public uint Width { get { return width; } set { width = value; } }
        public uint Height { get { return height; } set { height = value; } }

        public bool Visible { get => visible; set => visible = value; }

        public List(uint x, uint y, uint width, uint height)
        {
            this.X = x;
            this.Y = y;
            this.width = width;
            this.height = height;
        }
        public List(uint x, uint y)
        {
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
                c.DrawRectangle(new Pen(theme.BorderColor, theme.BorderSize), (int)X, (int)Y, (int)width, (int)height);


            foreach (Button btn in buttons)
            {
                btn.Draw(c);
            }
        }

        public void AddButton(Button btn)
        {
            if (btn != null)
            {
                uint buttonwidth = Width - 6;
                uint buttonheight = 40;
                uint buttonx = this.X + 3;
                uint buttony = this.Y + 3;

                if (buttons.Count >= 1)
                    buttony = this.Y+ 3 * (uint)buttons.Count + buttonheight * (uint)buttons.Count;

                btn.Width = buttonwidth;
                btn.Height = buttonheight;
                btn.X = buttonx;
                btn.Y = buttony;
                this.buttons.Add(btn);
            }
        }

        public void RemoveAllButtons()
        {
            foreach (Button btn in buttons)
            {
                buttons.Remove(btn);

            }
        }

        public override void Update()
        {
            // Verify if the panel is visible
            foreach (Button ctrl in buttons)
            {
                ctrl.Update();
            }
        }
    }
}

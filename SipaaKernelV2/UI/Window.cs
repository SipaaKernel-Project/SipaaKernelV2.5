using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.UI
{
    public class Window : Control
    {
        private uint width = 150, height = 150;
        private bool visible = false;
        private Rectangle titleBarArea;
        private string title;
        private List<Control> controls = new List<Control>();

        public List<Control> Controls { get { return controls; } set { controls = value; } }
        public uint Width { get { return width; } set { width = value; } }
        public uint Height { get { return height; } set { height = value; } }
        public string Title { get { return title; } set { title = value; } }

        public bool Visible { get => visible; set => visible = value; }

        public Window(uint x, uint y, uint width, uint height)
        {
            titleBarArea = new Rectangle((int)x, (int)y, (int)width, 48);
            this.X = x;
            this.Y = y;
            this.width = width;
            this.height = height;
        }

        public override void Draw(Canvas c)
        {
            // Verify if the panel is visible
            if (visible == true)
            {
                // Window drawing
                c.DrawFilledRectangle(ColorPens.idleButtonPen, (int)X, (int)Y, (int)Width, (int)Height); // Draw panel rectangle
                c.DrawRectangle(ColorPens.lightGrayPen, (int)X, (int)Y, (int)width, (int)height);
                c.DrawFilledRectangle(ColorPens.hoverButtonPen, titleBarArea.X, titleBarArea.Y, titleBarArea.Width, titleBarArea.Height);
                c.DrawRectangle(ColorPens.lightGrayPen, titleBarArea.X, titleBarArea.Y, titleBarArea.Width, titleBarArea.Height + 1);

                c.DrawString(Title, Kernel.font, ColorPens.whitePen, (int)X+4, (int)Y + 4);
                foreach (Control ctrl in Controls)
                {
                    ctrl.Draw(c);
                }
            }
        }

        public override void Update()
        { 
            // Verify if the panel is visible
            if (visible)
            {
                foreach (Control ctrl in Controls)
                {
                    ctrl.Update();
                }
            }
        }
    }
}

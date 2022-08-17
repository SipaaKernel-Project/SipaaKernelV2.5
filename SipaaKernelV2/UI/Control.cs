using Cosmos.System.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.UI
{
    public class Control
    {
        private uint y;
        private uint x;

        public uint X { get { return x; } set { x = value; } }
        public uint Y { get { return y; } set { y = value; } }

        public virtual void Draw(Canvas c) { }

        public virtual void Update() { }
    }
}

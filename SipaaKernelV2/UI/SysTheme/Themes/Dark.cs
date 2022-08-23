using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SipaaKernelV2.UI.SysTheme.Themes
{
    public class Dark : ThemeBase
    {
        public Dark()
        {
            ThemeId = 0;
            ThemeName = "SipaaKernel Dark";

            BorderSize = 0;
            BorderColor = Color.Black;

            BackColor = Color.FromArgb(32, 32, 32);
            HoveredBackColor = Color.FromArgb(64, 64, 64);
            ClickedBackColor = Color.FromArgb(12, 12, 12);
            AppBackColor = Color.Black;

            ForeColor = Color.White;
        }
    }
}

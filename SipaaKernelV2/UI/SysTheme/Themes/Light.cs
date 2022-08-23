using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SipaaKernelV2.UI.SysTheme.Themes
{
    public class Light : ThemeBase
    {
        public Light()
        {
            ThemeId = 1;
            ThemeName = "SipaaKernel Light";

            BorderSize = 0;
            BorderColor = Color.White;

            BackColor = Color.FromArgb(223, 223, 223);
            HoveredBackColor = Color.FromArgb(191, 191, 191);
            ClickedBackColor = Color.FromArgb(243, 243, 243);
            AppBackColor = Color.White;

            ForeColor = Color.Black;
        }
    }
}

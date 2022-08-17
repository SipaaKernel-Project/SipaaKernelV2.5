using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.UI.SysTheme
{
    internal class ThemeManager
    {
        private static ThemeBase currentTheme = new Themes.Dark();

        public static void SetCurrentTheme(ThemeBase theme) { if (currentTheme == null) { return; } currentTheme = theme; }

        public static ThemeBase GetCurrentTheme() { return currentTheme; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IL2CPU.API.Attribs;

namespace SipaaKernelV2.Core
{
    public class Files
    {
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.pointer.bmp")]
        public static byte[] Cursor;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.Wallpaper.bmp")]
        public static byte[] Wallpaper;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.sipaakernellogo.bmp")]
        public static byte[] OSLogo;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.sipaakernellogolight.bmp")]
        public static byte[] OSLogoLight;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.checkedcheckbox.bmp")]
        public static byte[] CheckedCheckBox;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.checkbox.bmp")]
        public static byte[] CheckBox;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.error.bmp")]
        public static byte[] Error;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.folder.bmp")]
        public static byte[] Folder;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.file.bmp")]
        public static byte[] File;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.uilib.bmp")]
        public static byte[] UILibrary;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.about.bmp")]
        public static byte[] AboutOS;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.sipad.bmp")]
        public static byte[] Sipad;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.ssd.bmp")]
        public static byte[] SSD;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.shutdown.bmp")]
        public static byte[] Shutdown;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.restart.bmp")]
        public static byte[] Reboot;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.settings.bmp")]
        public static byte[] Settings;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.throwex.bmp")]
        public static byte[] ThrowException;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.consolemode.bmp")]
        public static byte[] ConsoleMode;
        [ManifestResourceStream(ResourceName = "SipaaKernelV2.Resources.font.psf")]
        public static byte[] Font;
    }
}

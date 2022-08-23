using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using SipaaKernelV2.UI.SysTheme;
using SipaaKernelV2.UI.SysTheme.Themes;
using Cosmos.System.Graphics;
using Cosmos.System;

namespace SipaaKernelV2.Core.Readers
{
    public struct Config
    {
        public string ThemeIDString;
        public string ScreenWidth;
        public string ScreenHeight;
    }

    public class ConfigFileReader
    {
        public static Config DefaultConfig = new Config() { ThemeIDString = "0", ScreenWidth = "1280", ScreenHeight="720" };
        static string ConfigFilePath = @"0:\SipaaKernel\config.skc";

        public static void LoadConfig()
        {
            if (File.Exists(ConfigFilePath))
            {
                foreach (string l in File.ReadAllLines(ConfigFilePath))
                {
                    string val = l.Split('=')[1];
                    if (l.StartsWith("ThemeId"))
                    {
                        int valInt = int.Parse(val);
                        switch (valInt)
                        {
                            case 0:
                                ThemeManager.SetCurrentTheme(new Dark());
                                break;
                            case 1:
                                ThemeManager.SetCurrentTheme(new Light());
                                break;
                            default:
                                System.Console.WriteLine("[CONFIGREADER] Unknown theme! Loading default theme...");
                                ThemeManager.SetCurrentTheme(new Dark());
                                break;
                        }
                    }
                    else if (l.StartsWith("ScreenWidth"))
                    {
                        uint sWidth = uint.Parse(val);
                        Mode m = new Mode((int)sWidth, (int)Kernel.ScreenHeight, ColorDepth.ColorDepth32);
                        Kernel.c.Mode = m;
                        Kernel.ScreenWidth = sWidth;
                        MouseManager.ScreenWidth = sWidth;
                    }
                    else if (l.StartsWith("ScreenHeight"))
                    {
                        uint sHeight = uint.Parse(val);
                        Mode m = new Mode((int)Kernel.ScreenWidth, (int)sHeight, ColorDepth.ColorDepth32);
                        Kernel.c.Mode = m;
                        Kernel.ScreenHeight = sHeight;
                        MouseManager.ScreenHeight = sHeight;
                    }
                }
            }
            else
            {
                CreateConfigFile(DefaultConfig);
                LoadConfig();
            }
        }

        public static void CreateConfigFile(Config c)
        {
            StreamWriter w = new StreamWriter(ConfigFilePath);
            w.WriteLine("ThemeId=" + c.ThemeIDString);
            w.WriteLine("ScreenWidth=" + c.ScreenWidth);
            w.WriteLine("ScreenHeight=" + c.ScreenWidth);
        }
    }
}
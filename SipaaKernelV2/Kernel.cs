using Sys = Cosmos.System;
using System;
using Cosmos.System.Graphics;
using Cosmos.System.Graphics.Fonts;
using Cosmos.HAL;
using Cosmos.Core.Memory;
using SipaaKernelV2.UI;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;
using SipaaKernelV2.Applications;
using SipaaKernelV2.Core;
using SipaaKernelV2.Core.Translations;
using SipaaKernelV2.Core.FileSystem;
using SipaaKernelV2.Core.Keyboard;

namespace SipaaKernelV2
{
    public class Kernel : Sys.Kernel
    {
        public static Canvas c;
        public static Font font = PCScreenFont.LoadFont(Files.Font);
        public const string OSName = "SipaaKernel V2.5";
        public const double OSVersion = 22.9, OSBuild = 1124.234;
        public static uint
            ScreenWidth = 1280,
            ScreenHeight = 720;
        public static bool GUIMode = false;
        internal static Application CurrentApplication;
        public static byte _deltaT;
        public static bool Pressed;
        public static object FreeCount;
        public static int _fps;
        public static int _frames;
        public static CosmosVFS vfs;
        public static LanguageBase language = new EnglishLang();
        public static bool booting;
        public static int bootprogress;
        internal static bool DisableGUI;

        protected override void OnBoot()
        {
            try
            {
                base.OnBoot();
            }
            catch (System.Exception ex)
            {
                CrashScreen.DisplayKernelErrorAndReboot(ex.Message);
            }
        }

        protected override void BeforeRun()
        {
            OpenApplication(new BootApp());
            GoToGUIMode();
            if (!FSDriver.Initialize())
                Console.WriteLine("Cannot init filesystem!");
            booting = true;
        }

        internal static void OpenApplication(Application app)
        {
            if (app == null) return;
            CurrentApplication = app;
        }

        public static void ConsoleMode()
        {
            c.Disable();
            GUIMode = false;
            if (!Shell.LoadedCommands)
                Shell.LoadCommands();
        }

        public static void GoToGUIMode()
        {
            c = FullScreenCanvas.GetFullScreenCanvas(new Mode((int)ScreenWidth, (int)ScreenHeight, ColorDepth.ColorDepth32));
            Sys.MouseManager.ScreenWidth = ScreenWidth;
            Sys.MouseManager.ScreenHeight = ScreenHeight;

            GUIMode = true;
        }

        protected override void Run()
        {
            try
            {
                if (GUIMode)
                {
                    if (_deltaT != RTC.Second)
                    {
                        _fps = _frames;
                        _frames = 0;
                        _deltaT = RTC.Second;
                    }

                    _frames++;

                    FreeCount = Heap.Collect();

                    if (booting)
                    {
                        bootprogress++;
                        if (CurrentApplication != null)
                        {
                            CurrentApplication.Draw(c);
                            CurrentApplication.Update();
                        }
                        if (bootprogress == 250)
                        {
                            booting = false;
                            OpenApplication(new SipaaDesktop());
                        }
                    }
                    else
                    {
                        KBPS2.Update();

                        if (CurrentApplication != null)
                        {
                            CurrentApplication.Draw(c);
                            CurrentApplication.Update();
                        }

                        c.DrawImageAlpha(Bitmaps.cursor, (int)Sys.MouseManager.X, (int)Sys.MouseManager.Y);
                    }

                    c.Display();
                }
                else
                {
                    Shell.GetInput();
                }
            }
            catch (Exception ex)
            {
                if (GUIMode) 
                    OpenApplication(new CrashApp(ex));
                else
                    CrashScreen.DisplayAndReboot(ex.Message);
            }
        }
    }
}

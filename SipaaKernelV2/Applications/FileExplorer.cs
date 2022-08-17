using Cosmos.System.Graphics;
using SipaaKernelV2.Core;
using SipaaKernelV2.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SipaaKernelV2.Applications
{
    internal class FileExplorer : Application
    {
        Button mainDrive;
        List fileDirList;
        List shortAcessList;

        public FileExplorer()
        {
            ApplicationName = "File Explorer";
            ApplicationDeveloper = "RaphMar2019";
            ApplicationVersion = 1.0;
            AppIcon = Bitmaps.folder;
            shortAcessList = new List(3, 35, 250, Kernel.ScreenHeight - 32 - 6);
            fileDirList = new List(256, 35, Kernel.ScreenWidth - 9 - 250, Kernel.ScreenHeight - 32 - 6);
            mainDrive = new Button(@"0:\", 0, 0);
            mainDrive.Bitmap = Bitmaps.ssd;
            shortAcessList.AddButton(mainDrive);
        }
        private void NavigateTo(string dir)
        {
            if (Directory.Exists(dir))
            {
                fileDirList.RemoveAllButtons();
                foreach (string d in Directory.GetDirectories(dir))
                {
                    FileInfo i = new FileInfo(d);
                    Button b = new Button(i.Name + " (Directory)", 0, 0) { Bitmap = Bitmaps.folder };
                    fileDirList.AddButton(b);
                }
                foreach (string f in Directory.GetFiles(dir))
                {
                    FileInfo i = new FileInfo(f);
                    Button b = new Button(i.Name, 0, 0) { Bitmap = Bitmaps.file };
                    fileDirList.AddButton(b);
                }
            }
        }
        public override void Draw(Canvas c)
        {
            base.Draw(c);
            shortAcessList.Draw(c);
            fileDirList.Draw(c);
        }
        public override void Update()
        {
            base.Update();
            shortAcessList.Update();
            fileDirList.Update();
            if (mainDrive.ButtonState == ButtonState.Clicked)
            {
                NavigateTo(@"0:\");
            }
        }
    }
}

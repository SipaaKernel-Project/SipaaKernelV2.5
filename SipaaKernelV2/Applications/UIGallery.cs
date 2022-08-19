using Cosmos.System.Graphics;
using SipaaKernelV2.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SipaaKernelV2.UI;

namespace SipaaKernelV2.Applications
{
    internal class UIGallery : Application
    {
        Button sampleButton;
        TextBox sampleTextBox;
        TextView sampleTextView;
        CheckBox sampleCheckBox;
        Panel samplePanel;
        List sampleList;

        public UIGallery()
        {
            ApplicationName = "Sipaa UI Library";
            ApplicationDeveloper = "RaphMar2019";
            ApplicationVersion = 1.0;
            AppIcon = Bitmaps.uilib;
            sampleButton = new Button("Sample Button", 8, 52, 200, 40);
            sampleButton.Bitmap = Bitmaps.cursor;
            sampleButton.BorderRadius = 11;
            sampleTextView = new TextView("Click on Sample Button to toggle sample panel visibility.", 8, 38);
            sampleTextBox = new TextBox(8, 138);
            sampleCheckBox = new CheckBox("Do you like SipaaKernel?", 8, 100);
            samplePanel = new Panel(8, sampleTextBox.Y + 6, 200, 200);
            sampleList = new List(8, 200 + samplePanel.Height + 6);
            sampleList.AddButton(new Button("never", 0, 0));
            sampleList.AddButton(new Button("gonna", 0, 0));
            sampleList.AddButton(new Button("give", 0, 0));
            sampleList.AddButton(new Button("you", 0, 0));
            sampleList.AddButton(new Button("up", 0, 0));
        }

        public override void Draw(Canvas c)
        {
            base.Draw(c);
            sampleButton.Draw(c);
            sampleCheckBox.Draw(c);
            sampleTextView.Draw(c);
            samplePanel.Draw(c);
            sampleTextBox.Draw(c);
            sampleList.Draw(c);
        }
        public override void Update()
        {
            base.Update();
            samplePanel.Update();
            sampleButton.Update();
            sampleCheckBox.Update();
            sampleTextBox.Update();
            sampleTextView.Update();
            sampleList.Update();
            if (sampleButton.ButtonState == ButtonState.Clicked)
            {
                samplePanel.Visible = !samplePanel.Visible;
            }
        }
    }
}

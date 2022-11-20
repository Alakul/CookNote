using System;
using System.Collections.Generic;
using System.Text;

namespace CookNote.CustomMessageBox
{
    public class NewMessageBox : MessageBoxWindow
    {
        public new void Show()
        {
            ShowDialog();
        }
    }
}

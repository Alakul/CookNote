using CookNote.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookNote.Files
{
    internal class FileContext
    {
        private IFile iFile;

        public void SetFileType(FileEnum.Types type)
        {
            switch (type)
            {
                case FileEnum.Types.Text:
                    iFile = new TextFile();
                    break;
            }
        }

        public void SaveFile(Recipe recipe){
            iFile.ShowFileDialog(recipe);
        }
    }
}

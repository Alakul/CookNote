using CookNote.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Text;

namespace CookNote.Files
{
    public interface IFile
    {
        public void ShowFileDialog(Recipe recipe);
        public void SaveFile(bool? result, SaveFileDialog saveFileDialog, Recipe recipeItem);
    }
}

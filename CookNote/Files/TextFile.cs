using CookNote.Models;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;

namespace CookNote.Files
{
    public class TextFile: IFile
    {
        public void ShowFileDialog(Recipe recipe)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file|*.txt";
            bool? result = saveFileDialog.ShowDialog();
            SaveFile(result, saveFileDialog, recipe);
        }
        public void SaveFile(bool? result, SaveFileDialog saveFileDialog, Recipe recipeItem)
        {
            if (result == true){
                using (StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName, false))
                {
                    streamWriter.WriteLine(recipeItem.Title);
                    streamWriter.WriteLine("");
                    if (recipeItem.Description != ""){
                        streamWriter.WriteLine(recipeItem.Description);
                        streamWriter.WriteLine("");
                    }
                    streamWriter.WriteLine("Kategoria");
                    streamWriter.WriteLine(recipeItem.Category);
                    streamWriter.WriteLine("");

                    streamWriter.WriteLine("Składniki");
                    streamWriter.WriteLine(recipeItem.Ingredients);
                    streamWriter.WriteLine("");

                    streamWriter.WriteLine("Przygotowanie");
                    streamWriter.WriteLine(recipeItem.Method);

                    streamWriter.Close();
                }
                CustomMessageBox.CustomMessageBox.ShowNoWarning("Pomyślnie zapisano do pliku.", "", "Komunikat");
            }
        }
    }
}

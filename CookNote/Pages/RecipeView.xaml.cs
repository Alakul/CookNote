using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using CookNote.Models;

namespace CookNote.Pages
{
    public partial class RecipeView : UserControl
    {
        private Recipe recipeItem;

        public RecipeView(Recipe recipe)
        {
            InitializeComponent();

            SetMenuTemplate();
            SetRecipeValues(recipe);
            recipeItem = recipe;
        }

        private void SetMenuTemplate()
        {
            menuControl.header.Text = "PRZEPIS";
        }

        private void SetRecipeValues(Recipe recipe)
        {
            Recipe recipeFull = SqliteDataAccess.GetRecipe(recipe);
            title.Text = recipeFull.Title;
            if (recipeFull.Description == ""){
                descriptionStackPanel.Visibility = Visibility.Collapsed;
            }
            else {
                description.Text = recipeFull.Description;
            }
            category.Text = recipeFull.Category;
            ingredients.Text = recipeFull.Ingredients;
            method.Text = recipeFull.Method;

            if (recipeFull.Image != ""){
                string imageFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");

                try {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.UriSource = new Uri(System.IO.Path.Combine(imageFolder, recipeFull.Image));
                    bitmapImage.EndInit();

                    image.Source = bitmapImage;
                }
                catch (FileNotFoundException){
                    image.Source = null;
                }
                catch (DirectoryNotFoundException){
                    image.Source = null;
                }
            }
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeFormEdit(recipeItem));
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno usunąć?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No){
            }
            else {
                string imageFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
                Directory.CreateDirectory(imageFolder);
                string destinationPath = System.IO.Path.Combine(imageFolder, recipeItem.Image);
                image.Source = null;

                File.Delete(destinationPath);

                SqliteDataAccess.DeleteRecipe(recipeItem);
                Switcher.Switch(new RecipesList());
            }
        }

        private void SaveToTXTButton(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text file|*.txt";
            bool? result = saveFileDialog.ShowDialog();

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
            }
        }
    }
}

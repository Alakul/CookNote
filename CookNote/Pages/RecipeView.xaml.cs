using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using CookNote.Models;
using CookNote.Files;

namespace CookNote.Pages
{
    public partial class RecipeView : UserControl
    {
        private Recipe recipeItem;
        FileContext fileContext;
        public RecipeView(Recipe recipe)
        {
            InitializeComponent();

            SetMenuTemplate();
            SetRecipeValues(recipe);

            recipeItem = recipe;
            fileContext = new FileContext();
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
                string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");

                try {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.UriSource = new Uri(Path.Combine(imageFolder, recipeFull.Image));
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
                string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
                Directory.CreateDirectory(imageFolder);
                string destinationPath = Path.Combine(imageFolder, recipeItem.Image);
                image.Source = null;
                if (recipeItem.Image != ""){
                    File.Delete(destinationPath);
                }

                SqliteDataAccess.DeleteRecipe(recipeItem);
                Switcher.Switch(new RecipesList());
            }
        }

        private void SaveToTXTButton(object sender, RoutedEventArgs e)
        {
            fileContext.SetFileType(FileEnum.Types.Text);
            fileContext.SaveFile(recipeItem);
        }
    }
}

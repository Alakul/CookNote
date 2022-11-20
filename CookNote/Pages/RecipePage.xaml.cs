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
    public partial class RecipePage : UserControl
    {
        private Recipe recipeItem;
        FileContext fileContext;
        public RecipePage(Recipe recipe)
        {
            InitializeComponent();

            SetMenuTemplate();
            SetRecipeValues(recipe);

            recipeItem = recipe;
            fileContext = new FileContext();
        }

        private void SetMenuTemplate()
        {
            menuControl.backButton.AddHandler(Border.MouseDownEvent, new RoutedEventHandler(BackButton));
            menuControl.header.Text = "PRZEPIS";

            menuControl.buttonRight.AddHandler(Button.ClickEvent, new RoutedEventHandler(DeleteButton));
            menuControl.buttonRight.Content = "USUŃ";

            menuControl.buttonLeft.AddHandler(Button.ClickEvent, new RoutedEventHandler(EditFormButton));
            menuControl.buttonLeft.Content = "EDYTUJ";
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipesListPage());
        }

        private void EditFormButton(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeEditPage(recipeItem));
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
                    image.Margin = new Thickness(0, 10, 0, 10);
                }
                catch (FileNotFoundException){
                    image.Source = null;
                    image.Margin = new Thickness(0, 0, 0, 0);
                }
                catch (DirectoryNotFoundException){
                    image.Source = null;
                    image.Margin = new Thickness(0, 0, 0, 0);
                }
            }
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (CustomMessageBox.CustomMessageBox.ShowWithCancel("Czy na pewno usunąć?", "Ta akcja jest nieodwracalna", "Usuwanie przepisu") == MessageBoxResult.OK){
                string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
                Directory.CreateDirectory(imageFolder);
                string destinationPath = Path.Combine(imageFolder, recipeItem.Image);
                image.Source = null;
                if (recipeItem.Image != ""){
                    File.Delete(destinationPath);
                }

                SqliteDataAccess.DeleteRecipe(recipeItem);
                Switcher.Switch(new RecipesListPage());
            }
        }

        private void SaveToTXTButton(object sender, RoutedEventArgs e)
        {
            fileContext.SetFileType(FileEnum.Types.Text);
            fileContext.SaveFile(recipeItem);
        }
    }
}

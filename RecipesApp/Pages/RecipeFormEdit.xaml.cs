using Microsoft.Win32;
using RecipesApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipesApp.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy RecipeFormEdit.xaml
    /// </summary>
    public partial class RecipeFormEdit : UserControl
    {
        RecipeViewModel recipeViewModel;
        Recipe recipeValue;
        string fileNameFull;

        public RecipeFormEdit(Recipe recipe)
        {
            InitializeComponent();

            SetValues();
            SetViewModel(recipe);
            recipeValue = recipe;
        }

        private void SetValues()
        {
            menuControl.header.Text = "EDYTUJ PRZEPIS";
            formControl.actionButton.Content = "EDYTUJ PRZEPIS";
        }

        private void SetViewModel(Recipe recipe)
        {
            recipeViewModel = new RecipeViewModel();
            Recipe recipeFull = SqliteDataAccess.GetRecipe(recipe);

            recipeViewModel.Title = recipeFull.Title;
            recipeViewModel.Description = recipeFull.Description;
            recipeViewModel.Category = recipeFull.Category;
            recipeViewModel.Ingredients = recipeFull.Ingredients;
            recipeViewModel.Method = recipeFull.Method;

            if (recipeFull.Image != ""){
                string imageFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");

                try {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.UriSource = new Uri(System.IO.Path.Combine(imageFolder, recipeFull.Image));
                    bitmapImage.EndInit();

                    formControl.image.Source = bitmapImage;
                    formControl.file.Text = recipeFull.Image;
                    fileNameFull = bitmapImage.ToString();
                }
                catch (DirectoryNotFoundException){
                }
                catch (FileNotFoundException){
                }
            }
            else if (recipeFull.Image == ""){
                fileNameFull = "";
            }

            formControl.category.ItemsSource = RecipeData.categories;
            formControl.category.SelectedValue = recipeFull.Category;

            DataContext = recipeViewModel;
        }

        private void EditRecipe(object sender, RoutedEventArgs e)
        {
            if (recipeValue.Title != formControl.title.Text.Trim() && SqliteDataAccess.CheckForRecipes(formControl.title.Text.Trim()) != 0){
                MessageBox.Show("Istnieje przepis o tym tytule!");
            }
            else {
                MessageBox.Show("Message");
                recipeValue.Title = formControl.title.Text.Trim();
                recipeValue.Description = formControl.description.Text.Trim();
                recipeValue.Ingredients = formControl.ingredients.Text.Trim();
                recipeValue.Method = formControl.method.Text.Trim();
                recipeValue.Category = formControl.category.Text.Trim();
                recipeValue.Date = DateTime.Now;

                if (fileNameFull != ""){
                    string fileNameText = formControl.file.Text;
                    string fileName = recipeValue.Id.ToString() + fileNameText.Substring(fileNameText.IndexOf('.'));
                    
                    string imageFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
                    Directory.CreateDirectory(imageFolder);
                    string destinationPath = System.IO.Path.Combine(imageFolder, recipeValue.Image);

                    if (recipeValue.Image != ""){
                        File.Delete(destinationPath);
                    }

                    destinationPath = System.IO.Path.Combine(imageFolder, fileName);
                    File.Copy(fileNameFull, destinationPath);
                    recipeValue.Image = fileName;
                }
                else if (fileNameFull == ""){
                    if (recipeValue.Image != ""){
                        string imageFolder = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
                        Directory.CreateDirectory(imageFolder);
                        string destinationPath = System.IO.Path.Combine(imageFolder, recipeValue.Image);
                        File.Delete(destinationPath);

                        recipeValue.Image = "";
                    }
                }
                SqliteDataAccess.UpdateRecipe(recipeValue);
            }
        }

        private void SelectFileButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            var result = openFileDialog.ShowDialog();

            if (result == true){
                string filename = openFileDialog.FileName;
                string imagePath = filename.ToString();
                imagePath = imagePath.Substring(imagePath.LastIndexOf("\\"));
                imagePath = imagePath.Remove(0, 1);

                fileNameFull = filename;
                formControl.file.Text = imagePath;
                formControl.image.Source = new BitmapImage(new Uri(filename));
            }
        }

        private void DeleteFileButton(object sender, RoutedEventArgs e)
        {
            fileNameFull = "";
            formControl.file.Text = "";
            formControl.image.Source = null;
        }
    }
}

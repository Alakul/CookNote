using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using CookNote.Models;

namespace CookNote.Pages
{
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
                string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");

                try {
                    BitmapImage bitmapImage = new BitmapImage();
                    bitmapImage.BeginInit();
                    bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                    bitmapImage.UriSource = new Uri(Path.Combine(imageFolder, recipeFull.Image));
                    bitmapImage.EndInit();

                    formControl.image.Source = bitmapImage;
                    formControl.file.Text = recipeFull.Image;
                    fileNameFull = bitmapImage.ToString();
                }
                catch (FileNotFoundException){
                    formControl.image.Source = null;
                    formControl.file.Text = "";
                    fileNameFull = "";
                }
                catch (DirectoryNotFoundException){
                    formControl.image.Source = null;
                    formControl.file.Text = "";
                    fileNameFull = "";
                }
            }
            else if (recipeFull.Image == ""){
                fileNameFull = "";
            }

            List<string> list = RecipeData.categories;
            list.Sort();
            formControl.category.ItemsSource = list;
            formControl.category.SelectedValue = recipeFull.Category;

            DataContext = recipeViewModel;
        }

        private void EditRecipe(object sender, RoutedEventArgs e)
        {
            if (recipeValue.Title != formControl.title.Text.Trim() && SqliteDataAccess.CheckForRecipes(formControl.title.Text.Trim()) != 0){
                MessageBox.Show("Istnieje przepis o podanym tytule!");
            }
            else {
                if (formControl.title.Text.Trim()=="" || formControl.ingredients.Text.Trim()==""
                    || formControl.method.Text.Trim()=="" || formControl.category.Text.Trim()==""){
                    MessageBox.Show("Uzupełnij wszystkie wymagane pola!");
                }
                else {
                    recipeValue.Title = formControl.title.Text.Trim();
                    recipeValue.Description = formControl.description.Text.Trim();
                    recipeValue.Ingredients = formControl.ingredients.Text.Trim();
                    recipeValue.Method = formControl.method.Text.Trim();
                    recipeValue.Category = formControl.category.Text.Trim();
                    recipeValue.Date = DateTime.Now;

                    if (fileNameFull != ""){
                        string fileNameText = formControl.file.Text;
                        if (fileNameText != ""){
                            string fileName = recipeValue.Id.ToString() + fileNameText.Substring(fileNameText.LastIndexOf('.'));

                            string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
                            Directory.CreateDirectory(imageFolder);
                            string destinationPath = Path.Combine(imageFolder, fileName);
                            string path = Path.Combine(imageFolder, recipeValue.Image);

                            if (File.Exists(path) && destinationPath != path){
                                File.Delete(path);
                            }

                            if (fileNameText != recipeValue.Image){
                                File.Copy(fileNameFull, destinationPath, true);
                            }

                            recipeValue.Image = fileName;
                        }
                        else if (fileNameText == ""){
                            recipeValue.Image = "";
                        }
                    }
                    else if (fileNameFull == ""){
                        if (recipeValue.Image != ""){
                            string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
                            Directory.CreateDirectory(imageFolder);
                            string destinationPath = Path.Combine(imageFolder, recipeValue.Image);
                            File.Delete(destinationPath);

                            recipeValue.Image = "";
                        }
                    }
                    SqliteDataAccess.UpdateRecipe(recipeValue);
                    MessageBox.Show("Pomyślnie edytowano przepis.");
                }
            }
        }

        private void SelectFileButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|JPEG Files (*.jpeg)|*.jpeg";
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

using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using CookNote.Models;

namespace CookNote.Pages
{
    public partial class RecipeAddPage : UserControl
    {
        string fileNameFull;

        public RecipeAddPage()
        {
            InitializeComponent();

            SetViewModel();
            SetValues();
        }

        private void SetViewModel()
        {
            RecipeViewModel recipeViewModel = new RecipeViewModel();
            DataContext = recipeViewModel;
        }

        private void SetValues()
        {
            menuControl.backButton.AddHandler(Border.MouseDownEvent, new RoutedEventHandler(BackButton));
            menuControl.header.Text = "DODAJ PRZEPIS";
            formControl.actionButton.Content = "DODAJ PRZEPIS";
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipesListPage());
        }

        private void AddRecipe(object sender, RoutedEventArgs e)
        {
            if (SqliteDataAccess.CheckForRecipes(formControl.title.Text.Trim())!=0) {
                CustomMessageBox.CustomMessageBox.Show("Istnieje przepis o podanym tytule!", "", "Komunikat");
            }
            else {
                if (formControl.title.Text.Trim() == "" || formControl.ingredients.Text.Trim() == ""
                    || formControl.method.Text.Trim() == "" || formControl.category.Text.Trim() == ""){
                    CustomMessageBox.CustomMessageBox.Show("Uzupełnij wszystkie wymagane pola!", "", "Komunikat");
                }
                else {
                    Recipe recipe = new Recipe()
                    {
                        Title = formControl.title.Text.Trim(),
                        Description = formControl.description.Text.Trim(),
                        Ingredients = formControl.ingredients.Text.Trim(),
                        Method = formControl.method.Text.Trim(),
                        Category = formControl.category.SelectedItem.ToString(),
                        Date = DateTime.Now
                    };
                    SqliteDataAccess.InsertRecipe(recipe);
                    string fileNameText = formControl.file.Text;

                    if (fileNameText == ""){
                        recipe.Image = "";
                        SqliteDataAccess.UpdateRecipe(recipe);
                    }
                    else if (fileNameText != ""){
                        recipe.Image = recipe.Id.ToString() + fileNameText.Substring(fileNameText.LastIndexOf('.'));
                        SqliteDataAccess.UpdateRecipe(recipe);

                        string fileName = recipe.Image;
                        string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
                        Directory.CreateDirectory(imageFolder);
                        string destinationPath = Path.Combine(imageFolder, fileName);
                        File.Copy(fileNameFull, destinationPath);
                    }
                    CustomMessageBox.CustomMessageBox.ShowNoWarning("Pomyślnie dodano przepis.", "", "Komunikat");
                }
            }
        }

        private void SelectFileButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|JPEG Files (*.jpeg)|*.jpeg";
            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
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
            formControl.file.Text = "";
            formControl.image.Source = null;
            fileNameFull = null;
        }
    }
}

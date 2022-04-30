using Microsoft.Win32;
using RecipesApp.Models;
using System;
using System.Collections.Generic;
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

            formControl.category.ItemsSource = RecipeData.categories;
            formControl.category.SelectedValue = recipeFull.Category;

            DataContext = recipeViewModel;
        }

        private void EditRecipe(object sender, RoutedEventArgs e)
        {
            if (SqliteDataAccess.CheckForRecipes(formControl.title.Text.Trim()) != 0){
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

                SqliteDataAccess.UpdateRecipe(recipeValue);
            }
        }

        private void SelectFileButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".png";
            openFileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            var result = openFileDialog.ShowDialog();

            if (result == true)
            {
                string filename = openFileDialog.FileName;
                formControl.file.Text = filename;

                formControl.image.Source = new BitmapImage(new Uri(filename));
            }
        }
    }
}

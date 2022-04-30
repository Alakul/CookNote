using Microsoft.Win32;
using RecipesApp.Models;
using RecipesApp.Templates;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
    /// Logika interakcji dla klasy RecipeForm.xaml
    /// </summary>
    public partial class RecipeFormAdd : UserControl
    {
        List<Tuple<string, string, string>> ingList = new List<Tuple<string, string, string>>();
        RecipeViewModel recipeViewModel;

        public RecipeFormAdd()
        {
            InitializeComponent();

            SetViewModel();
            SetValues();
        }
        private void SetViewModel()
        {
            recipeViewModel = new RecipeViewModel();
            DataContext = recipeViewModel;
        }

        private void SetValues()
        {
            menuControl.header.Text = "DODAJ PRZEPIS";
            formControl.actionButton.Content = "DODAJ PRZEPIS";
        }

        private void AddRecipe(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Message");
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
        }
        
        private void SelectFileButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".png";
            openFileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            var result = openFileDialog.ShowDialog();
            
            if (result == true){ 
                string filename = openFileDialog.FileName;
                formControl.file.Text = filename;

                formControl.image.Source = new BitmapImage(new Uri(filename));
            }
        }
    }
}

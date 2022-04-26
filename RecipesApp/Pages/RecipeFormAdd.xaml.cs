using Microsoft.Win32;
using RecipesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            category.ItemsSource = RecipeData.categories;
            MenuTemplate mt = new MenuTemplate();
            mt.header.Text = "DODAJ PRZEPIS";
            contentControlMenu.Content = mt;

            category.ItemsSource = RecipeData.categories;
            category.SelectedIndex = 0;
            measurement.ItemsSource = RecipeData.typeList;
            measurement.SelectedIndex = 0;

            recipeViewModel = new RecipeViewModel();
            DataContext = recipeViewModel;
        }

        private void SaveRecipe(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ingredientList.Items.Count; i++){
                ingList.Add(new Tuple<string, string, string>(ingredientType.Text, amount.Text, measurement.SelectedValue.ToString()));
            }

            Recipe recipe = new Recipe()
            {
                Title = title.Text,
                Description = description.Text,
                Method = method.Text,
                Category = category.SelectedItem.ToString(),
            };
            SqliteDataAccess.SaveRecipe(recipe);

            for (int i = 0; i < ingList.Count; i++){
                Ingredient ingredient = new Ingredient()
                {
                    RecipeId = recipe.Id,
                    IngredientType = ingList[i].Item1,
                    Amount = ingList[i].Item2,
                    Measurement = ingList[i].Item3
                };
                SqliteDataAccess.SaveIngredient(ingredient);
            }
        }
       
        private void AddIngredientButton(object sender, RoutedEventArgs e)
        {
            
        }
        /*
        private void DeleteIngredientButton(object sender, RoutedEventArgs e)
        {

        }
        */
        private void SelectFileButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".png";
            openFileDialog.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            var result = openFileDialog.ShowDialog();
            
            if (result == true){ 
                string filename = openFileDialog.FileName;
                file.Text = filename;

                image.Source = new BitmapImage(new Uri(filename));
            }
        }
    }
}

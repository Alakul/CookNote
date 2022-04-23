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
    /// Logika interakcji dla klasy RecipesList.xaml
    /// </summary>
    public partial class RecipesList : UserControl
    {
        List<Recipe> recipes;

        public RecipesList()
        {
            InitializeComponent();
            recipes = new List<Recipe>();
            LoadRecipes();
        }

        private void AddRecipe(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeForm());
        }

        private void LoadRecipes()
        {
            List<Recipe> recipes = SqliteDataAccess.ListRecipes();
            recipesList.ItemsSource = recipes;
        }

        private void ListViewMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem;
            if (item != null)
            {
                Switcher.Switch(new RecipeView());
            }
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var item = button.DataContext as Recipe;
            SqliteDataAccess.DeleteRecipe(item);
            LoadRecipes();
        }
    }
}

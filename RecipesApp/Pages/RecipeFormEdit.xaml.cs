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
        public RecipeFormEdit(Recipe recipe)
        {
            InitializeComponent();

            SetMenuTemplate();
            SetViewModel(recipe);
        }

        private void SetMenuTemplate()
        {
            MenuTemplate menuTemplate = new MenuTemplate();
            menuTemplate.header.Text = "EDYTUJ PRZEPIS";
            contentControlMenu.Content = menuTemplate;
        }

        private void SetViewModel(Recipe recipe)
        {
            recipeViewModel = new RecipeViewModel();
            DataContext = recipeViewModel;

            Recipe recipeFull = SqliteDataAccess.GetRecipe(recipe);

            recipeViewModel.Title = recipeFull.Title;
            recipeViewModel.Description = recipeFull.Description;
            recipeViewModel.Category = recipeFull.Category;
            recipeViewModel.Method = recipeFull.Method;

            category.ItemsSource = RecipeData.categories;
            category.SelectedValue = recipeFull.Category;

            ingredientList.Items.Clear();
            ingredientList.ItemsSource = recipeFull.Ingredients;
        }

        private void SaveRecipe(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

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

            SetMenuTemplate();
            SetViewModel(recipe);
            recipeValue = recipe;
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
            Recipe recipeFull = SqliteDataAccess.GetRecipe(recipe);

            recipeViewModel.Title = recipeFull.Title;
            recipeViewModel.Description = recipeFull.Description;
            recipeViewModel.Category = recipeFull.Category;
            recipeViewModel.Ingredients = recipeFull.Ingredients;
            recipeViewModel.Method = recipeFull.Method;

            category.ItemsSource = RecipeData.categories;
            category.SelectedValue = recipeFull.Category;

            DataContext = recipeViewModel;
        }

        private void EditRecipe(object sender, RoutedEventArgs e)
        {
            recipeValue.Title = title.Text.Trim();
            recipeValue.Description = description.Text.Trim();
            recipeValue.Ingredients = ingredients.Text.Trim();
            recipeValue.Method = method.Text.Trim();
            recipeValue.Category = category.Text.Trim();
            recipeValue.Date = DateTime.Now;

            SqliteDataAccess.UpdateRecipe(recipeValue);
        }
    }
}

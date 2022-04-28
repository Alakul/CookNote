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
    /// Logika interakcji dla klasy RecipeView.xaml
    /// </summary>
    public partial class RecipeView : UserControl
    {
        private Recipe recipeItem;

        public RecipeView(Recipe recipe)
        {
            InitializeComponent();

            SetMenuTemplate();
            SetRecipeValues(recipe);
            recipeItem = recipe;
        }

        private void SetMenuTemplate()
        {
            MenuTemplate menuTemplate = new MenuTemplate();
            menuTemplate.header.Text = "PRZEPIS";
            contentControlMenu.Content = menuTemplate;
        }

        private void SetRecipeValues(Recipe recipe)
        {
            Recipe recipeFull = SqliteDataAccess.GetRecipe(recipe);
            
            title.Text = recipeFull.Title;
            description.Text = recipeFull.Description;
            category.Text = recipeFull.Category;
            ingredients.Text = recipeFull.Ingredients;
            method.Text = recipeFull.Method;
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeFormEdit(recipeItem));
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno usunąć?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No){
            }
            else {
                SqliteDataAccess.DeleteRecipe(recipeItem);
                Switcher.Switch(new RecipesList());
            }
        }
    }
}

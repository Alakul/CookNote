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
    /// Logika interakcji dla klasy RecipeForm.xaml
    /// </summary>
    public partial class RecipeForm : UserControl
    {
        public RecipeForm()
        {
            InitializeComponent();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipesList());
        }

        private void SaveRecipe(object sender, RoutedEventArgs e)
        {
            Recipe recipe = new Recipe()
            {
                Title = title.Text,
                Method = method.Text,
                Category = "C"
            };

            SqliteDataAccess.SaveRecipe(recipe);




            for (int i=0; i< 1; i++)
            {
                Ingredient ingredient = new Ingredient()
                {
                    IngredientType = "d",
                    Amount = 4,
                    Measurement = "f"
                };
                SqliteDataAccess.SaveIngredient(ingredient);
            }
        }
       
    }
}

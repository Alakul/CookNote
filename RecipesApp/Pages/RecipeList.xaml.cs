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

            List<string> categoryList = new List<string>(RecipeData.categories);
            categoryList.Insert(0, "Wszystko");
            category.ItemsSource = categoryList;
            category.SelectedIndex = 0;

            sort.ItemsSource = RecipeData.sortList;
            sort.SelectedIndex = 0;
        }

        private void AddRecipe(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeFormAdd());
        }

        private void LoadRecipes()
        {
            List<Recipe> recipes = SqliteDataAccess.ListRecipes();
            recipesList.ItemsSource = recipes;
        }

        private void ListViewMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            object item = (sender as ListView).SelectedItem;
            Recipe itemRec = (Recipe)item;
            if (item != null){
                Switcher.Switch(new RecipeView(itemRec));
            }
        }

        private void DeleteButton(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno usunąć?", "Usuwanie", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No){
                
            }
            else {
                Button button = (Button)sender;
                Recipe item = button.DataContext as Recipe;
                SqliteDataAccess.DeleteRecipe(item);
                LoadRecipes();
            }
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            
        }
    }
}

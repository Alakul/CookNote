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
        private List<Recipe> recipes;
        string categoryName;
        string orderValue;
        string orderType;
        string searchValue;

        public RecipesList()
        {
            InitializeComponent();

            SetComboBoxValues();
            SetValues();
            RecipesToList();
        }

        private void SetComboBoxValues()
        {
            List<string> categoryList = new List<string>(RecipeData.categories);
            categoryList.Insert(0, "Wszystko");
            category.ItemsSource = categoryList;
            category.SelectedIndex = 0;

            sort.ItemsSource = RecipeData.sortList;
            sort.SelectedIndex = 0;
        }

        private void SetValues()
        {
            searchValue = "";
            categoryName = "";
            orderValue = "title";
            orderType = "ascending";
            recipes = new List<Recipe>();
        }

        private void AddRecipe(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeFormAdd());
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Recipe item = button.DataContext as Recipe;
            if (item != null)
            {
                Switcher.Switch(new RecipeFormEdit(item));
            }
        }

        private void ListViewMouseLeftButtonDown(object sender, RoutedEventArgs e)
        {
            object item = (sender as ListView).SelectedItem;
            Recipe recipeItem = (Recipe)item;
            if (item != null){
                Switcher.Switch(new RecipeView(recipeItem));
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
                RecipesToList();
            }
        }

        private void SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            if (category.SelectedValue.ToString() == "Wszystko"){
                categoryName = "";
            }
            else {
                categoryName = category.SelectedValue.ToString();
            }
            RecipesToList();
        }

        private void SortChange(object sender, SelectionChangedEventArgs e)
        {
            switch (sort.SelectedIndex)
            {
                case 0:
                    orderValue = "title";
                    orderType = "ascending";
                    break;
                case 1:
                    orderValue = "title";
                    orderType = "descending";
                    break;
                case 2:
                    orderValue = "date";
                    orderType = "ascending";
                    break;
                case 3:
                    orderValue = "date";
                    orderType = "descending";
                    break;
            }
            RecipesToList();
        }

        private void RecipesToList()
        {
            List<Recipe> recipes = SqliteDataAccess.ListRecipes(searchValue, categoryName, orderValue, orderType);
            recipesList.ItemsSource = recipes;
        }

        private void SearchForRecipes(object sender, RoutedEventArgs e)
        {
            searchValue = search.Text;
            RecipesToList();
        }
    }
}

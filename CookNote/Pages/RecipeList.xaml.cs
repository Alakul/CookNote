using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using CookNote.Models;

namespace CookNote.Pages
{
    public partial class RecipesList : UserControl
    {
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
            categoryList.Sort();
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
            
        }

        private void AddRecipeButton(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipeFormAdd());
        }

        private void EditButton(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Recipe item = button.DataContext as Recipe;
            if (item != null){
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

                if (item.Image != ""){
                    string imageFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images");
                    Directory.CreateDirectory(imageFolder);
                    string destinationPath = Path.Combine(imageFolder, item.Image);
                    File.Delete(destinationPath);
                }
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

        private void SearchForRecipesButton(object sender, RoutedEventArgs e)
        {
            searchValue = search.Text;
            RecipesToList();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new MainMenu());
        }
    }
}

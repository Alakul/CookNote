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
        ObservableCollection<ListViewItem> items = new ObservableCollection<ListViewItem>();

        public RecipeFormAdd()
        {
            InitializeComponent();
            category.ItemsSource = RecipeData.categories;
            MenuTemplate mt = new MenuTemplate();
            mt.header.Text = "DODAJ PRZEPIS";
            contentControlMenu.Content = mt;

            category.ItemsSource = RecipeData.categories;
            category.SelectedIndex = 0;

            type.ItemsSource = RecipeData.typeList;
            type.SelectedIndex = 0;

            //ingredientList.Items.Add();
        }

        private void SaveRecipe(object sender, RoutedEventArgs e)
        {
            Recipe recipe = new Recipe()
            {
                Title = title.Text,
                Method = method.Text,
                Category = category.SelectedItem.ToString()
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
       
        private void AddIngredientButton(object sender, RoutedEventArgs e)
        {

            items.Add(new ListViewItem());
            ingredientList.ItemsSource = items;
            //ingredientList.Items.Add();
        }

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

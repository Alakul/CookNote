﻿using Microsoft.Win32;
using RecipesApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

            SetMenuTemplate();
            SetComboBoxValues();
            SetViewModel();
        }

        private void SetMenuTemplate()
        {
            MenuTemplate menuTemplate = new MenuTemplate();
            menuTemplate.header.Text = "DODAJ PRZEPIS";
            contentControlMenu.Content = menuTemplate;
        }

        private void SetComboBoxValues()
        {
            category.ItemsSource = RecipeData.categories;
            category.SelectedIndex = 0;
            measurement.ItemsSource = RecipeData.typeList;
            measurement.SelectedIndex = 0;
        }

        private void SetViewModel()
        {
            recipeViewModel = new RecipeViewModel();
            DataContext = recipeViewModel;
        }

        private void SaveRecipe(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ingredientList.Items.Count; i++){
                ingList.Add(new Tuple<string, string, string>(ingredientType.Text, amount.Text, measurement.SelectedValue.ToString()));
            }

            List<Ingredient> ingredientsList = new List<Ingredient>();
            for (int i = 0; i < ingList.Count; i++)
            {
                Ingredient ingredient = new Ingredient()
                {
                    IngredientType = ingList[i].Item1.Trim(),
                    Amount = ingList[i].Item2,
                    Measurement = ingList[i].Item3
                };
                ingredientsList.Add(ingredient);

                //SqliteDataAccess.SaveIngredient(ingredient);
            }

            Recipe recipe = new Recipe()
            {
                Title = title.Text.Trim(),
                Description = description.Text.Trim(),
                Method = method.Text.Trim(),
                Category = category.SelectedItem.ToString(),
                Date = DateTime.Now,
                Ingredients = ingredientsList
            };
            SqliteDataAccess.SaveRecipe(recipe);
        }

        private void AddIngredientButton(object sender, RoutedEventArgs e)
        {
            ingredientList.Items.Add(new ItemsControl());
        }
        
        private void DeleteIngredientButton(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            Ingredient item = button.DataContext as Ingredient;
            ingredientList.Items.Remove(item);
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

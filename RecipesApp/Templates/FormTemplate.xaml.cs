using Microsoft.Win32;
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

namespace RecipesApp.Templates
{
    /// <summary>
    /// Logika interakcji dla klasy FormTemplate.xaml
    /// </summary>
    public partial class FormTemplate : UserControl
    {
        public delegate void MyControlClickEvent(object sender, RoutedEventArgs e);
        public event MyControlClickEvent RecipeButton;
        public event MyControlClickEvent ImageButton;
        public event MyControlClickEvent DeleteImageButton;

        public FormTemplate()
        {
            InitializeComponent();

            SetComboBoxValues();
        }

        private void SetComboBoxValues()
        {
            category.ItemsSource = RecipeData.categories;
            category.SelectedIndex = 0;
        }

        private void RecipeAction(object sender, RoutedEventArgs e)
        {
            RecipeButton?.Invoke(sender, e);
        }

        private void SelectFileButton(object sender, RoutedEventArgs e)
        {
            ImageButton?.Invoke(sender, e);
        }

        private void DeleteFileButton(object sender, RoutedEventArgs e)
        {
            DeleteImageButton?.Invoke(sender, e);
        }
    }
}

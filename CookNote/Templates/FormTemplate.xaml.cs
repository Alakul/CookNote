using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace CookNote.Templates
{
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
            List<string> list = RecipeData.categories;
            list.Sort();
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

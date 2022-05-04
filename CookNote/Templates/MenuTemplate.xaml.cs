using CookNote.Pages;
using System.Windows;
using System.Windows.Controls;

namespace CookNote.Templates
{
    public partial class MenuTemplate : UserControl
    {
        public MenuTemplate()
        {
            InitializeComponent();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipesList());
        }
    }
}

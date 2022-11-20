using CookNote.Pages;
using System.Windows;
using System.Windows.Controls;

namespace CookNote.Templates
{
    public partial class Header : UserControl
    {
        public Header()
        {
            InitializeComponent();
        }

        private void BackButton(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipesListPage());
        }
    }
}

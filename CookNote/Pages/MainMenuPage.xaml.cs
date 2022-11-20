using System.Windows;
using System.Windows.Controls;

namespace CookNote.Pages
{
    public partial class MainMenuPage : UserControl
    {
        public MainMenuPage()
        {
            InitializeComponent();
        }

        private void RecipeListViewButton(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipesListPage());
        }

        private void AuthorButton(object sender, RoutedEventArgs e)
        {
            CustomMessageBox.CustomMessageBox.ShowNoWarning("Autor: Alicja Kulig", "", "");
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

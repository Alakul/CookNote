using System.Windows;
using System.Windows.Controls;

namespace CookNote.Pages
{
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void RecipeListViewButton(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipesList());
        }

        private void AuthorButton(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Autor: Alicja Kulig");
        }

        private void CloseButton(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}

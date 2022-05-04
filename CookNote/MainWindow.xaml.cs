using CookNote.Pages;
using System.Windows;
using System.Windows.Controls;

namespace CookNote
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Switcher.pageSwitcher = this;
            Switcher.Switch(new RecipesList());
        }

        public void Navigate(UserControl nextPage)
        {
            contentControl.Content = nextPage;
        }

        public void BackButton(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipesList());
        }
    }
}

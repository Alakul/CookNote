using CookNote.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CookNote
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Switcher.pageSwitcher = this;
            Switcher.Switch(new MainMenuPage());
        }

        public void Navigate(UserControl nextPage)
        {
            contentControl.Content = nextPage;
        }

        public void BackButton(object sender, RoutedEventArgs e)
        {
            Switcher.Switch(new RecipesListPage());
        }

        private bool _isMouseDown = false;

        private void Drag_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = true;
            this.DragMove();
        }

        private void Drag_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            _isMouseDown = false;
        }
        private void Drag_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isMouseDown && this.WindowState == WindowState.Maximized)
            {
                _isMouseDown = false;
                this.WindowState = WindowState.Normal;
            }
        }
    }
}

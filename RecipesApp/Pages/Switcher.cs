using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace RecipesApp.Pages
{
    public static class Switcher
    {
        public static MainWindow pageSwitcher;

        public static void Switch(UserControl newPage)
        {
            pageSwitcher.Navigate(newPage);
        }
    }
}

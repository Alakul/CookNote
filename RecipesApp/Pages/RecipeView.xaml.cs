using RecipesApp.Models;
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

namespace RecipesApp.Pages
{
    /// <summary>
    /// Logika interakcji dla klasy RecipeView.xaml
    /// </summary>
    public partial class RecipeView : UserControl
    {
        public RecipeView(Recipe obj)
        {
            InitializeComponent();
            
            MenuTemplate mt = new MenuTemplate();
            mt.header.Text = "PRZEPIS";
            contentControlMenu.Content = mt;


            /*
            RecipeViewModel vm = new RecipeViewModel(obj, mt);
            DataContext = vm;
            */


            title.Text = obj.Title;
            method.Text = obj.Method;
        }
    }
}

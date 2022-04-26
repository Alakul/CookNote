﻿using RecipesApp.Pages;
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

namespace RecipesApp
{
    /// <summary>
    /// Logika interakcji dla klasy MenuTemplate.xaml
    /// </summary>
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

        private void EnterButton(object sender, RoutedEventArgs e)
        {
            imageArrow.Source = new BitmapImage(new Uri(@"/Images/arrowLightGray.png", UriKind.Relative));
        }

        private void LeaveButton(object sender, RoutedEventArgs e)
        {
            imageArrow.Source = new BitmapImage(new Uri(@"/Images/arrowWhite.png", UriKind.Relative));
        }
    }
}
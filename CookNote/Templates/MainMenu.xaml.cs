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

namespace CookNote.Templates
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        private void MinimizeApp_Click(object sender, EventArgs eventArgs)
        {
            Application.Current.Windows[0].WindowState = WindowState.Minimized;
        }
        private void CloseApp_Click(object sender, EventArgs eventArgs)
        {
            Application.Current.Shutdown();
        }
    }
}

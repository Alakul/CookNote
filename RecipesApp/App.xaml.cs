﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace RecipesApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "Recipes.db";
        static string folderPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string databasePath = System.IO.Path.Combine(folderPath, databaseName);
    }
}

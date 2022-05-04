using System;
using System.IO;
using System.Windows;

namespace CookNote
{
    public partial class App : Application
    {
        static string databaseName = "CookNote.db";
        static string folderPath = AppDomain.CurrentDomain.BaseDirectory;
        public static string databasePath = Path.Combine(folderPath, databaseName);
    }
}

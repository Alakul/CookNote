using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesApp
{
    public static class RecipeData
    {
        public static List<string> categories = new List<string>()
        {
            "Ciasta","Zupy", "Danie główne"
        };

        public static List<string> sortList = new List<string>()
        {
            "po nazwie rosnąco", "po nazwie malejąco", "po dacie rosnąco", "po dacie malejąco"
        };

        public static List<string> typeList = new List<string>()
        {
            "g","dag", "kg", "szt.", "łyżki", "ml", "szkl.", "ząbki", "l", "łyżeczki"
        };
    }
}

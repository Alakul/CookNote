using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesApp
{
    public static class RecipeData
    {
        public static List<string> categories = new List<string>()
        {
            "Dania główne","Przekąski","Sałatki","Zupy","Desery","Napoje"
        };

        public static List<string> sortList = new List<string>()
        {
            "po nazwie rosnąco", "po nazwie malejąco", "po dacie rosnąco", "po dacie malejąco"
        };
    }
}

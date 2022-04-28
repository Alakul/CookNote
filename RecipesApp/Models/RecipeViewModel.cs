using RecipesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesApp
{
    public class RecipeViewModel
    {
        public RecipeViewModel()
        {
            Title = "Tytuł";
            Method = "Przygotowanie";
            Ingredients = "Składniki";
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public string Method { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }
    }
}

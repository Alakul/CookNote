using RecipesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesApp
{
    public class RecipeViewModel
    {
        public List<Recipe> Items { get; set; }
        public Recipe Recipe { get; set; }

        public RecipeViewModel()
        {
            Items = new List<Recipe>();
            Items = SqliteDataAccess.ListRecipes();
        }
    }
}

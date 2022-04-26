using RecipesApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesApp
{
    public class RecipeViewModel
    {
        readonly Recipe recipe;
        readonly Ingredient ingredient;

        public RecipeViewModel(Recipe recipeM, Ingredient ingredientM)
        {
            this.recipe = recipeM;
            this.ingredient = ingredientM;
        }

    }
}

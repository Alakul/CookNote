using RecipesApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipesApp
{
    public class SqliteDataAccess
    {
        static List<Recipe> recipes = new List<Recipe>();
        static List<Ingredient> ingredients = new List<Ingredient>();

        public static List<Recipe> ListRecipes()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Recipe>();
                recipes = connection.Table<Recipe>().ToList().OrderBy(c => c.Title).ToList();
                connection.Close();
            }

            return recipes;
        }

        public static void SaveRecipe(Recipe recipe)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Recipe>();
                connection.Insert(recipe);
                connection.Close();
            }
        }

        public static void SaveIngredient(Ingredient ingredient)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Ingredient>();
                connection.Insert(ingredient);
                connection.Close();
            }
        }

        public static void DeleteRecipe(Recipe id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.Delete(id);
            }
        }

        public static List<Ingredient> GetIngredients(int id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                ingredients = connection.Table<Ingredient>().Where(c => c.RecipeId == id).ToList().OrderBy(c => c.IngredientType).ToList();
                connection.Close();
            }
            return ingredients;
        }
    }
}

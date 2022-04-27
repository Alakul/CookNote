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
                ingredients = connection.Table<Ingredient>().Where(c => c.RecipeId == id).OrderBy(c => c.IngredientType).ToList();
                connection.Close();
            }
            return ingredients;
        }

        public static List<Recipe> ListRecipes(string searchValue, string category, string orderValue, string orderType)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                if (category == ""){
                    if (orderType == "ascending"){
                        if (orderValue == "title"){
                            recipes = connection.Table<Recipe>().Where(c => c.Title.Contains(searchValue)).OrderBy(c => c.Title).ToList();
                        }
                        else if (orderValue == "date"){
                            recipes = connection.Table<Recipe>().Where(c => c.Title.Contains(searchValue)).OrderBy(c => c.Date).ToList();
                        }
                    }
                    else if (orderType == "descending"){
                        if (orderValue == "title"){
                            recipes = connection.Table<Recipe>().Where(c => c.Title.Contains(searchValue)).OrderByDescending(c => c.Title).ToList();
                        }
                        else if (orderValue == "date"){
                            recipes = connection.Table<Recipe>().Where(c => c.Title.Contains(searchValue)).OrderByDescending(c => c.Date).ToList();
                        }
                    }
                }
                else {
                    if (orderType == "ascending"){
                        if (orderValue == "title"){
                            recipes = connection.Table<Recipe>().Where(c => c.Category == category && c.Title.Contains(searchValue)).OrderBy(c => c.Title).ToList();
                        }
                        else if (orderValue == "date"){
                            recipes = connection.Table<Recipe>().Where(c => c.Category == category && c.Title.Contains(searchValue)).OrderBy(c => c.Date).ToList();
                        }
                    }
                    else if (orderType == "descending"){
                        if (orderValue == "title"){
                            recipes = connection.Table<Recipe>().Where(c => c.Category == category && c.Title.Contains(searchValue)).OrderByDescending(c => c.Title).ToList();
                        }
                        else if (orderValue == "date"){
                            recipes = connection.Table<Recipe>().Where(c => c.Category == category && c.Title.Contains(searchValue)).OrderByDescending(c => c.Date).ToList();
                        }
                    }
                }
                connection.Close();
            }
            return recipes;
        }
    }
}

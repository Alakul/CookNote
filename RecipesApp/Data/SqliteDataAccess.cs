using RecipesApp.Models;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RecipesApp
{
    public class SqliteDataAccess
    {
        static List<Recipe> recipes = new List<Recipe>();
        static Recipe recipeFull;

        public static void InsertRecipe(Recipe recipe)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Recipe>();
                connection.Insert(recipe);
                connection.Close();
            }
        }

        public static void UpdateRecipe(Recipe recipe)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Recipe>();
                connection.Update(recipe);
                connection.Close();
            }
        }

        public static void DeleteRecipe(Recipe id)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.Delete(id);
                connection.Close();
            }
        }

        public static Recipe GetRecipe(Recipe recipe)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                recipeFull = connection.Table<Recipe>().Where(c => c.Id == recipe.Id).FirstOrDefault();
            }
            return recipeFull;
        }

        public static List<Recipe> ListRecipes(string searchValue, string category, string orderValue, string orderType)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                if (category == ""){
                    if (orderType == "ascending"){
                        if (orderValue == "title"){
                            recipes = connection.Table<Recipe>().Where(c => c.Title.ToLower().Contains(searchValue.ToLower())).OrderBy(c => c.Title).ToList();
                        }
                        else if (orderValue == "date"){
                            recipes = connection.Table<Recipe>().Where(c => c.Title.ToLower().Contains(searchValue.ToLower())).OrderBy(c => c.Date).ToList();
                        }
                    }
                    else if (orderType == "descending"){
                        if (orderValue == "title"){
                            recipes = connection.Table<Recipe>().Where(c => c.Title.ToLower().Contains(searchValue.ToLower())).OrderByDescending(c => c.Title).ToList();
                        }
                        else if (orderValue == "date"){
                            recipes = connection.Table<Recipe>().Where(c => c.Title.ToLower().Contains(searchValue.ToLower())).OrderByDescending(c => c.Date).ToList();
                        }
                    }
                }
                else {
                    if (orderType == "ascending"){
                        if (orderValue == "title"){
                            recipes = connection.Table<Recipe>().Where(c => c.Category == category && c.Title.ToLower().Contains(searchValue.ToLower())).OrderBy(c => c.Title).ToList();
                        }
                        else if (orderValue == "date"){
                            recipes = connection.Table<Recipe>().Where(c => c.Category == category && c.Title.ToLower().Contains(searchValue.ToLower())).OrderBy(c => c.Date).ToList();
                        }
                    }
                    else if (orderType == "descending"){
                        if (orderValue == "title"){
                            recipes = connection.Table<Recipe>().Where(c => c.Category == category && c.Title.ToLower().Contains(searchValue.ToLower())).OrderByDescending(c => c.Title).ToList();
                        }
                        else if (orderValue == "date"){
                            recipes = connection.Table<Recipe>().Where(c => c.Category == category && c.Title.ToLower().Contains(searchValue.ToLower())).OrderByDescending(c => c.Date).ToList();
                        }
                    }
                }
                connection.Close();
            }
            return recipes;
        }
    }
}

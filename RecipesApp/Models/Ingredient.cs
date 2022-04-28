using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RecipesApp.Models
{
    public class Ingredient
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [SQLiteNetExtensions.Attributes.ForeignKey(typeof(Recipe))]
        public int RecipeId { get; set; }

        public string IngredientType { get; set; }
        public string Amount { get; set; }
        public string Measurement { get; set; }
    }
}

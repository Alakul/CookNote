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
        public string RecipeId { get; set; }
        public string IngredientType { get; set; }
        public double Amount { get; set; }
        public string Measurement { get; set; }

        [ManyToOne]
        public Recipe Recipe { get; set; }
    }
}

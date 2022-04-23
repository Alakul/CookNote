using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace RecipesApp.Models
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Method { get; set; }
        public string Category { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Method} - {Category}";
        }
    }
}

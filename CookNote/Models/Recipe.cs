﻿using SQLite;
using System;

namespace CookNote.Models
{
    public class Recipe
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set;}
        public string Ingredients { get; set; }
        public string Method { get; set; }
        public string Category { get; set; }
        public string Image { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Method} - {Category}";
        }
    }
}

using System.Collections.Generic;

namespace CookNote
{
    public static class RecipeData
    {
        public static List<string> categories = new List<string>()
        {
            "Śniadanie","Danie główne","Deser","Kolacja","Przekąska","Sałatka","Zupa","Napój","Inne"
        };
        public static List<string> sortList = new List<string>()
        {
            "po nazwie rosnąco", "po nazwie malejąco", "po dacie rosnąco", "po dacie malejąco"
        };
    }
}

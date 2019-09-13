using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpAppLab1
{
    public class Recipe
    {
        public Recipe()
        {
            Ingredients = new List<string>();
        }
        public int DishID { get; set; }
        public string DishName { get; set; }
        public List<string> Ingredients { get; set; }
        public int DishPrice { get; set; }
    }
}

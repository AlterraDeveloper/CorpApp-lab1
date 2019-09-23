using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorpAppLab1
{
    public class Recipe : ReferenceProvider
    {
        public Recipe()
        {
            IngredientsAsString = new List<string>();
        }

        public int DishID { get; set; }
        public string DishName { get; set; }
        public int DishPrice { get; set; }
        public List<string> IngredientsAsString { get; set; }
    }
}

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
            IngredientIdsAndQuantities = new Dictionary<int, int>();
        }

        public int DishID { get; set; }

        public Dictionary<int, int> IngredientIdsAndQuantities;
    }
}

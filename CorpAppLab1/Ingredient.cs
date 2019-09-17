namespace CorpAppLab1
{
    public class Ingredient : ReferenceProvider
    {
        public int IngredientID { get; set; }
        public string IngredientName { get; set; }
        public int UnitID { get; set; }
        public int UnitPrice { get; set; }

        public string auxUnitName { get; set; }
    }
}
using System;
using System.Collections.Generic;
using CorpAppLab1.DataAccessLayer;

namespace CorpAppLab1.Models
{
    public class Order : ReferenceProvider
    {
        public int OrderID { get; set; }
        public DateTime OrderDate { get; set; }
        public int Total { get; set; }
        public Dictionary<int,int> DishesAndCounts { get; set; }

        public Order()
        {
            OrderDate = DateTime.Now;
            DishesAndCounts = new Dictionary<int, int>();
        }

    }
}

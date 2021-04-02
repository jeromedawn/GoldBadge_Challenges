using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KomodoCafe_Repository
{

    public enum Ingredients 
    {
        Strawberry , Blueberry, Raspberry, Banana, Mango, Peach 
    }
    public class Menu
    {
        public string ItemName { get; set; }
        public double ItemNumber { get; set; }
        public string ItemDescription { get; set; }
        public double ItemPrice { get; set; }
        public string Ingredients { get; set; }
        public Menu(){}
        public Menu(string ordername, double ordernumber, string orderdescription, double ordercost, string ingredients)
        {
            ItemName = ordername; 
            ItemNumber = ordernumber;
            ItemDescription = orderdescription;
            ItemPrice = ordercost;
            Ingredients = ingredients;
        }
    }
}

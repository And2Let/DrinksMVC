using DrinksMVC.Data.Base;
using DrinksMVC.Models.Domain;

namespace DrinksMVC.Data
{
    public class WendingMachine : EntityBase<int>
    {
        public WendingMachine()
        {
            this.Drinks = new List<ListDrinks>();
        }
        public decimal Balance { get; set; }
        public virtual List<ListDrinks> Drinks { get; set; }
    }
}

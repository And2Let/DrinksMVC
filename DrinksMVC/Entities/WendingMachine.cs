using DrinksMVC.Data.Base;

namespace DrinksMVC.Entities
{
    public class WendingMachine : EntityBase<int>
    {
        public WendingMachine()
        {
            this.Drinks = new List<Drink>();
        }
        public decimal Balance { get; set; }
        public virtual List<Drink> Drinks { get; set; }
    }
}

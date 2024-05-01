using DrinksMVC.Data;
using DrinksMVC.Data.Base;

namespace DrinksMVC.Entities
{
    public class Coin : EntityBase<int>
    {
        public int Value { get; set; }

        public bool isAvailabe { get; set; }

        public virtual CoinStorage Storage { get; set; }

        public string ImageUrl { get; set; }    
    }
}

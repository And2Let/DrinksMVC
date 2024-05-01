using DrinksMVC.Data.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DrinksMVC.Data
{
    public class Coin : EntityBase<int>
    {
        public int Value { get; set; }
        public bool isAvailable { get; set; }
        public virtual CoinStorage Storage { get; set; }
        public string ImageUrl { get; set; }
    }
}

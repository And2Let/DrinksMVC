using DrinksMVC.Data.Base;

namespace DrinksMVC.Entities
{
    public class CoinStorage : EntityBase<int>
    {
        public CoinStorage()
        {
            this.Coins = new List<Coin>();
        }
        public virtual List<Coin> Coins { get; set; }
        public int CountCoins { get; set; }
    }
}

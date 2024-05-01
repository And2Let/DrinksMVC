using DrinksMVC.Data;
using DrinksMVC.Interfaces.Base;
namespace DrinksMVC.Interfaces
{
    public interface ICoinStorage : IBase<CoinStorage, int>
    {
        CoinStorage GetAllCoins();
        Coin GetCoin(decimal value);
    }
}

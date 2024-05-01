using DrinksMVC.Interfaces.Base;
using DrinksMVC.Models.Domain;

namespace DrinksMVC.Interfaces
{
    public interface IDrinks : IBase<ListDrinks, int>
    {
        ListDrinks Get(int Id);
    }
}

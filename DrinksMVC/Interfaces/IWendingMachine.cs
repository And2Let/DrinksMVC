using DrinksMVC.Data;
using DrinksMVC.Interfaces.Base;
using DrinksMVC.Models.Domain;

namespace DrinksMVC.Interfaces
{
    public interface IWendingMachine : IBase<WendingMachine, int>
    {
        WendingMachine GetMachineById(int machineId);
        WendingMachine GetMachineByBalance(decimal balance);
        WendingMachine GetMachineBy();
        List<ListDrinks> GetAvailableDrinks(int machineId);
        ListDrinks GetDrink(int drinkId);
        decimal GetBalance(int machineId);
        decimal AddCash(int machineId, decimal Cash);
        decimal SubCash(int machineId, decimal Cash);
    }
}

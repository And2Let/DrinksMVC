using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Contracts.DTO;

namespace AppServices.Interfaces
{
    public interface IDrinkService
    {
        DrinkDto GetDrinkById(int drinkId);
        void CreateDrink(int machineId, DrinkDto drinkDto);
        void DeleteDrink(int drinkDtoId);
        IList<DrinkDto> GetAll();
        int AddDrink(int machine, int drinkId, int count);
    }
}

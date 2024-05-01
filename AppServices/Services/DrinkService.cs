using AppServices.Interfaces;
using AutoMapper;
using DrinksMVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Contracts.DTO;

namespace AppServices.Services
{
    public class DrinkService : IDrinkService
    {
        protected readonly IDrinks drinks;
        protected readonly IWendingMachine wendingMachine;

        public DrinkService(IDrinks drinks, IWendingMachine wendingMachine)
        {
            this.drinks = drinks;
            this.wendingMachine = wendingMachine;
        }
        public void CreateDrink(int machineId, DrinkDto drinkDto)
        {
            var machine = this.wendingMachine.GetMachineBy();

            machine.Drinks.Add(Mapper.Map<Drink>(drinkDto));
            this.wendingMachine.Update(machine);
        }
        public void DeleteDrink(DrinkDto drinkDto)
        {
            this.drinks.Delete(drinkDto.Id);
        }
        public void DeleteDrink(int drinkDto)
        {
            this.drinks.Delete(drinkDto);
        }
        public IList<DrinkDto> GetAll()
        {
            var drinks = this.drinks.GetAll().ToList();
            var result = Mapper.Map<IList<DrinkDto>>(drinks);
            return result;
        }

        public DrinkDto GetDrinkById(int drinkId)
        {
            DrinkService drink = this.drinks.Get(drinkId);
            if(drink == null)
            {
                throw new ArgumentException($"Не найден напиток с Id = {drinkId}");

            }
            var result = new DrinkDto
            {
                Id = drink.Id,
                Name = drink.Name,
                Price = drink.Price
            };
            return result;
        }
        
        public int AddDrink(int machineId, int drinkId, int count)
        {
            var machine = this.wendingMachine.GetMachineById(machineId);
            var new1 = machine.Drinks.FirstOrDefault(x => x.Id == drinkId).Count += count;
            this.wendingMachine.Update(machine);
            return machine.Drinks.FirstOrDefault(x => x.Id == drinkId).Count;
        }
    }
}

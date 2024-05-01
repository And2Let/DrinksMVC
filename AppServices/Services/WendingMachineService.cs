using AppServices.Interfaces;
using AutoMapper;
using DrinksMVC.Data;
using DrinksMVC.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Contracts.DTO;

namespace AppServices.Services
{
    public class WendingMachineService : IWendingMachineService
    {
        private readonly IWendingMachine wendingMachine;
        private readonly IDrinks drinks;
        private readonly IDrinkService drinkService;
        private readonly IHelpService helpService;

        public WendingMachineService(IWendingMachine wendingMachine, IDrinks drinks, IDrinkService drinkService, IHelpService helpService)
        {
            this.wendingMachine = wendingMachine;
            this.drinks = drinks;
            this.drinkService = drinkService;
            this.helpService = helpService;
        }

        public void AddDrinkToMachine(int machineId, int drinkId, int count)
        {
            this.drinkService.AddDrink(machineId, drinkId, count);
        }
        public void CreateDrink(int machineId, DrinkDto newDrink)
        {
            this.drinkService.CreateDrink(machineId, newDrink);
        }
        public List<DrinkDto> GetAvailableDrink(int machineId)
        {
            var machine = this.wendingMachine.GetMachineByBalance(machineId);
            return machine.Drinks.Select(Mapper.Map<DrinkDto>).Where(x => x.isAvailable == true && x.Count > 0).ToList();
        }
        public List<DrinkDto> GetAllDrinks(int machineId)
        {
            var machine = this.wendingMachine.GetMachineBy();
            return machine.Drinks.Select(Mapper.Map<DrinkDto>).ToList();
        }
        public WendingMachineDto GetMachineByBalance(decimal balance)
        {
            WendingMachine machine = this.wendingMachine.GetMachineByBalance(balance);
            return Mapper.Map<WendingMachineDto>(machine);
        }
        public WendingMachineDto GetMachineBy()
        {
            WendingMachine machine = this.wendingMachine.GetMachineById(machineId);

            return Mapper.Map<WendingMachineDto>(machine);
        }

        public WendingMachineDto GetMachineById(int machineId)
        {
            WendingMachine machine = this.wendingMachine.GetMachineById(machineId);

            return Mapper.Map<WendingMachineDto>(machine);
        }

        public void OrderDrink(int drinkId)
        {
            var machine = this.wendingMachine.GetMachineBy();
            var drink = machine.Drinks.FirstOrDefault(x => x.Id == drinkId);
            if(drink.Count > 0 && machine.Balance >= drink.Price)
            {
                drink.Count--;
                machine.Balance -= drink.Price;
                this.wendingMachine.Update(machine);
            }
            else
            {
                throw new ArgumentNullException($"Count of drink {drink.Name} less than 1");
            }
        }
        public decimal AddBalance(decimal Cash)
        {
            if(Cash > 0)
            {
                var machine = this.wendingMachine.GetMachineBy();
                machine.Balance += Cash;
                this.wendingMachine.Update(machine);
            }
            return this.wendingMachine.GetMachineBy().Balance;
        }
        public decimal SubBalance(decimal Cash)
        {
            var machine = this.wendingMachine.GetMachineBy();
            if (machine.Balance >= Cash)
            {
                machine.Balance -= Cash;
                this.wendingMachine.Update(machine);
                return machine.Balance;
            }
            else
            {
                return machine.Balance;
            }
        }
        public void makeNotAvailableDrink(int id)
        {
            this.wendingMachine.GetDrink(id).isAvailable = false;
            this.wendingMachine.Update(this.wendingMachine.GetMachineBy());
        }
        public void MakeAvailableDrink(int id)
        {
            this.wendingMachine.GetDrink(id).isAvailable = true;
            this.wendingMachine.Update(this.wendingMachine.GetMachineBy());
        }
        public void TakeTips()
        {
            var machine = this.wendingMachine.GetMachineBy();
            machine.Balance = 0;
            this.wendingMachine.Update(machine);
        }
    }
}

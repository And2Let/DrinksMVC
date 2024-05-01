using AppServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;
using WebApi.Contracts.DTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class WendingMachineController : Controller
    {
        protected readonly IDrinkService drinkService;
        protected readonly IWendingMachineService wendingMachineService;
        private readonly IHelpService helpService;

        public WendingMachineController(IDrinkService drinkService, IWendingMachineService wendingMachineService, IHelpService helpService)
        {
            this.drinkService = drinkService;
            this.wendingMachineService = wendingMachineService;
            this.helpService = helpService;
        }
        [HttpGet]
        [Route("GetCoins")]
        public CoinStorageDto GetCoins()
        {
            return this.helpService.GetAllCoins();
        }
        [HttpPost]
        [Route("MakeNotAvailableCoin/{value}")]
        public void MakeNotAvailableCoin(decimal value)
        {
            this.helpService.MakeNotAvailableCoin(value);
        }
        [HttpPost]
        [Route("MakeAvailableCoin/{value}")]
        public void MakeAvailableCoin(decimal value)
        {
            this.helpService.MakeAvailableCoin(value);
        }

        [HttpPost]
        [Route("MakeNotAvailableDrink/{id}")]
        public void MakeNotAvailableDrink(int id)
        {
            this.wendingMachineService.MakeNotAvailableDrink(id);
        }

        [HttpGet]
        [Route("MakeAvailableDrink/{id}")]
        public void MakeAvailableDrink(int id)
        {
            this.wendingMachineService.MakeAvailableDrink(id);
        }

        [HttpGet]
        [Route("GetMachine/{id}")]
        public WendingMachineDto GetMachine(decimal balance)
        {
            return this.wendingMachineService.GetMachineBy();
        }
        [HttpGet]
        [Route("GetAvailableDrinks")]
        public List<DrinkDto> GetAvailableDrinks(int wendingMachineId = 1)
        {
            return this.wendingMachineService.GetAvailableDrink(wendingMachineId);
        }
        [HttpPost]
        [Route("CreateDrink")]
        public List<DrinkDto> CreateDrink([FromBody] DrinkDto newDrink, int machineId = 0)
        {
            this.wendingMachineService.CreateDrink(machineId, newDrink);
            return this.wendingMachineService.GetAllDrinks(machineId);
        }

        [HttpPost]
        [Route("AddDrink")]
        public void AddDrink(int machineId, int drinkId, int count)
        {
            this.wendingMachineService.AddDrinkmachine(machineId, drinkId, count);
        }

        [HttpPost]
        [Route("AddBalanceCoin/{add}")]
        public decimal AddBalanceCoin(decimal add)
        {
            if (add < 0)
            {
                throw new ArgumentNullException("Cash cant be < 0");
            }
            decimal newBalance = this.wendingMachineService.AddBalance(add);
            return newBalance;
        }

        [HttpPost]
        [Route("AddBalanceAdmin/{add}")]
        public decimal AddBalance(decimal add)
        {
            if (add < 0)
            {
                throw new ArgumentNullException("Cash cant be < 0");
            }
            decimal newBalance = this.wendingMachineService.AddBalance(add);
            return newBalance;
        }
        [HttpPost]
        [Route("SubBalanceAdmin/{sub}")]
        public decimal SubBalance(decimal sub)
        {
            this.wendingMachineService.SubBalance(sub);
            return this.wendingMachineService.GetMachineBy().Balance;
        }



        [HttpGet]
        [Route("Taketips")]
        public void Taketips()
        {
            this.wendingMachineService.TakeTips();
        }

        [HttpPost]
        [Route("OrderDrink/{drinkId}")]
        public void OrderDrink(int drinkId)
        {
            this.wendingMachineService.OrderDrink(drinkId);
        }
    }
}

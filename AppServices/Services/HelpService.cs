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
    public class HelpService : Interfaces.IHelpService
    {
        protected readonly ICoin coin;
        protected readonly ICoinStorage coinStorage;
        protected readonly IServiceProvider serviceProvider;

        public HelpService(ICoin coin, ICoinStorage coinStorage, IServiceProvider serviceProvider)
        {
            this.coin = coin;
            this.coinStorage = coinStorage;
            this.serviceProvider = serviceProvider;
        }

        public void MakeNotAvailableCoin(decimal value)
        {
            this.coinStorage.GetCoin(value).isAvailable = false;
            this.coinStorage.Update(this.coinStorage.GetAllCoins());   
        }
        public void MakeAvailableCoin(decimal value)
        {
            this.coinStorage.GetCoin(value).isAvailable = true;
            this.coinStorage.Update(this.coinStorage.GetAllCoins());
        }

        public void FillCoinStorage()
        {
            throw new NotImplementedException();
        }
        public CoinStorageDto GetAllCoins()
        {
            var storage = this.coinStorage.GetAllCoins();

            return Mapper.Map<CoinStorageDto>(storage);
        }

        public void AddCoins()
        {
            throw new NotImplementedException();
        }
    }
}

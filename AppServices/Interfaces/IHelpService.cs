using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Contracts.DTO;

namespace AppServices.Interfaces
{
    public interface IHelpService
    {
        void AddCoins();
        void FillCoinStorage();
        CoinStorageDto GetAllCoins();
        void MakeNotAvailableCoin(decimal value);
        void MakeAvailableCoin(decimal value);
    }
}

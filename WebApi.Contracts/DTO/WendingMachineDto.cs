using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Contracts.DTO.Base;

namespace WebApi.Contracts.DTO
{
    public class WendingMachineDto : EntityDto<int>
    {
        public decimal Balance { get; set; }

        public List<DrinkDto> Drinks { get; set; }
    }
}

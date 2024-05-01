using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Contracts.DTO.Base;

namespace WebApi.Contracts.DTO
{
    public class CoinDto : EntityDto<int>
    {
        public int Value { get; set; }

        public bool isAvailable { get; set; }

        public string ImageUrl { get; set; }
    }
}

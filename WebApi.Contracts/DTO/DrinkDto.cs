﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Contracts.DTO.Base;

namespace WebApi.Contracts.DTO
{
    public class DrinkDto : EntityDto<int>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public int Count { get; set; }

        public bool isAvailable { get; set; }

        public string ImageUrl { get; set; }  
    }
}

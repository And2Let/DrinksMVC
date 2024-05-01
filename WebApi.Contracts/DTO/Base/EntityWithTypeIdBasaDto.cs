using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Contracts.DTO.Base
{
    public abstract class EntityWithTypeIdBasaDto<TId>
    {
        public virtual TId Id { get; set; }
    }
}

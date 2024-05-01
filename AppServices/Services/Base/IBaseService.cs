using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Contracts.DTO.Base;

namespace AppServices.Services.Base
{
    public interface IBaseService<T> where T : EntityWithTypeIdBasaDto<T>
    {
        IQueryable<T> GetAll();
        T Get();
    }
}

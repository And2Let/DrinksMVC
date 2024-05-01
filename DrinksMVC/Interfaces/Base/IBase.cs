using DrinksMVC.Data.Base;

namespace DrinksMVC.Interfaces.Base
{
    public class IBase<T, TId> where T : EntityWithTypedIdBase<TId>
    {
        IQueryable<T> GetAll();
        TId Create(T entity);
        TId Update(T entity);
        void Delete(TId entityId);
    }
}

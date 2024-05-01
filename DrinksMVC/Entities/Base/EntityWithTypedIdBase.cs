﻿namespace DrinksMVC.Entities.Base
{
    public abstract class EntityWithTypedIdBase<TId>
    {
        public virtual TId Id { get; protected set; }
    }
}

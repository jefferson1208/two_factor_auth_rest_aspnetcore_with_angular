using System;

namespace TFA.Api.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        IUnitOfWork UnitOfWork { get; }
    }
}

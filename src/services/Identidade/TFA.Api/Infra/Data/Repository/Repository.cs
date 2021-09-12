﻿using TFA.Api.Domain.Interfaces;
using TFA.Api.Infra.Data.Context;

namespace TFA.Api.Infra.Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
    {
        private readonly ApplicationDbContext _context;

        protected Repository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;

        public void Add(TEntity entity)
        {
            _context.Add(entity);
        }

        public void Remove(TEntity entity)
        {
            _context.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Update(entity);
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}

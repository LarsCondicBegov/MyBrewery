using Microsoft.EntityFrameworkCore;
using MyBrewery.Domain.Models;
using MyBrewery.Domain.Repositories;
using MyBrewery.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyBrewery.Application.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepositoryBase
        where TEntity : Entity
    {
        private readonly MyBreweryDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(MyBreweryDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken)
            => await _dbContext.SaveChangesAsync(cancellationToken);
    }
}

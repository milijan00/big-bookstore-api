using BigBookstore.Application.Dtos;
using BigBookstore.Domain.Entities;
using BigBookstore.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.Services
{
    public interface IApplicationService
    {
        public  Task<TEntity> GetByIdAsync<TEntity>( Guid id) where TEntity : BaseEntity ;
        public Task<IEnumerable<TEntity>> GetAsync<TEntity>()  where TEntity: BaseEntity ;
        public Task CreateAsync<TEntity>(TEntity entity) where TEntity : BaseEntity;
        public Task UpdateAsync<TEntity>( Guid id, TEntity entity) where TEntity : BaseEntity;
        public Task DeleteAsync<TEntity>(Guid id) where TEntity : BaseEntity;
        public DbSet<TEntity> Entity<TEntity>() where TEntity: class;
        public Task SaveChangesAsync();
    }
}

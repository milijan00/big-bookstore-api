using BigBookstore.Application.Dtos;
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
        public  Task<TEntity> GetByIdAsync<TEntity>( Guid id) where TEntity : class ;
        public Task<IEnumerable<TEntity>> GetAsync<TEntity>() where TEntity : class;
        public Task CreateAsync<TEntity>(TEntity entity) where TEntity : class;
        public Task UpdateAsync<TEntity, TDto>( Guid id, TDto entity) where TDto : BaseDto where TEntity : class;
        public Task DeleteAsync<TEntity>(Guid id);
        public Task<DbSet<TEntity>> Entity<TEntity>() where TEntity: class;
    }
}

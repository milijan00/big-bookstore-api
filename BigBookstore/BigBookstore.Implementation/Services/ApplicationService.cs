using BigBookstore.Application.Dtos;
using BigBookstore.Application.Services;
using BigBookstore.Domain.Entities;
using BigBookstore.Implementation.Exceptions;
using BigBookstore.Persistance;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Implementation.Services
{
    public class ApplicationService : IApplicationService
    {
        private readonly BigBookStoreDbContext _context;

        public ApplicationService(BigBookStoreDbContext context)
        {
            this._context = context;
        }

        public async  Task CreateAsync<TEntity>(TEntity entity) where TEntity : BaseEntity
        {
            if(entity == null)
            {
                throw new NullReferenceException($"Entity {nameof(TEntity)} is null.");
            }
            await this.Entity<TEntity>().AddAsync(entity);
            await this._context.SaveChangesAsync();
        }

        public async Task DeleteAsync<TEntity>(Guid id) where TEntity : BaseEntity
        {
            var entity = await this.Entity<TEntity>().FirstOrDefaultAsync(x => x.Id == id && x.IsActive);

            if(entity == null)
            {
                throw new EntityNotFoundException(nameof(TEntity), id);
            }
            entity.IsActive = false;
            await this._context.SaveChangesAsync();
        }

        public DbSet<TEntity> Entity<TEntity>() where TEntity : BaseEntity
        {
            var entity = this._context.Set<TEntity>();
            if(entity == null)
            {
                throw new DbSetNotFoundException($"DbSet {nameof(TEntity)} doesn't exist.", nameof(TEntity));
            }
            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAsync<TEntity>() where TEntity : BaseEntity
        {
            return await  this.Entity<TEntity>().Where(x => x.IsActive).ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync<TEntity>(Guid id) where TEntity : BaseEntity
        {
            var entity = await this.Entity<TEntity>().FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
            
            if(entity == null)
            {
                throw new EntityNotFoundException(nameof(TEntity), id);
            }

            return entity;
        }

        public async  Task SaveChangesAsync()
        {
            await this._context.SaveChangesAsync();
        }

        public Task UpdateAsync<TEntity>(Guid id, TEntity entity) where TEntity : BaseEntity
        {
            throw new NotImplementedException();
        }
    }
}

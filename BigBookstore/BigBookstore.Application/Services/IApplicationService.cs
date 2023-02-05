using BigBookstore.Persistance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BigBookstore.Application.Services
{
    public interface IApplicationService
    {
        public  Task<TEntity> GetByIdAsync<TEntity>( Guid id);
        public Task<IEnumerable<TEntity>> GetAsync<TEntity>();
        public Task CreateAsync<TEntity>(TEntity entity);
        // ToDo: Think of better solution for this update method
        public Task UpdateAsync<TEntity>(TEntity entity, Guid id);
        public Task DeleteAsync<TEntity>(Guid id);
    }
}

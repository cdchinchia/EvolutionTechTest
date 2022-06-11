using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionTechTest.Core.Interfaces
{
    public interface IRepositoryAsync<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetByIdAsync(int id);
        public Task<T> CreateAsync(T entity);
        public Task<T> UpdateAsync(T entity);        
        public Task RemoveAsync(T entity);
        public Task<bool> AnyAsync(int id);
    }
}

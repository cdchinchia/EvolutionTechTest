using EvolutionTechTest.Core.Entities;
using EvolutionTechTest.Core.Interfaces;
using EvolutionTechTest.Infrastructure.Respositories.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionTechTest.Infrastructure.Respositories
{
    public class UserRepository : IRepositoryAsync<User>
    {
        private readonly EvolutionTestContext _evolutionTestContext;

        public UserRepository(EvolutionTestContext evolutionTestContext)
        {
            _evolutionTestContext = evolutionTestContext;
        }

        public async Task<bool> AnyAsync(int id) =>
            await _evolutionTestContext.Users.AnyAsync(x => x.Id == id);

        public async Task<User> CreateAsync(User entity)
        {
            _evolutionTestContext.Add(entity);
            await _evolutionTestContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _evolutionTestContext.Users.OrderBy(x => x.Name).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _evolutionTestContext.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(User entity)
        {
            _evolutionTestContext.Remove(entity);
            await _evolutionTestContext.SaveChangesAsync();
        }
        public async Task<User> UpdateAsync(User entity)
        {
            //_evolutionTestContext.Entry(entity).State = EntityState.Modified;
            _evolutionTestContext.Users.Update(entity);
            await _evolutionTestContext.SaveChangesAsync();
            return entity;
        }
    }
}

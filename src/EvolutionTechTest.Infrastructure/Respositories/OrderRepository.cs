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
    public class OrderRepository : IRepositoryAsync<Order>
    {
        private readonly EvolutionTestContext _evolutionTestContext;

        public OrderRepository(EvolutionTestContext evolutionTestContext)
        {
            _evolutionTestContext = evolutionTestContext;
        }

        public async Task<bool> AnyAsync(int id) =>
            await _evolutionTestContext.Orders.AnyAsync(x => x.Id == id);

        public async Task<Order> CreateAsync(Order entity)
        {
            _evolutionTestContext.Add(entity);
            await _evolutionTestContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            IQueryable<Order> orders = _evolutionTestContext.Orders;
    
            return await orders.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _evolutionTestContext.Orders.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(Order entity)
        {
            _evolutionTestContext.Remove(entity);
            await _evolutionTestContext.SaveChangesAsync();
        }

        public async Task<Order> UpdateAsync(Order entity)
        {
            //_evolutionTestContext.Entry(entity).State = EntityState.Modified;
            _evolutionTestContext.Orders.Update(entity);
            await _evolutionTestContext.SaveChangesAsync();
            return entity;
        }
    }
}

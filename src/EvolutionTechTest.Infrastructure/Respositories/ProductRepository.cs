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
    public class ProductRepository : IRepositoryAsync<Product>
    {
        private readonly EvolutionTestContext _evolutionTestContext;
        public ProductRepository(EvolutionTestContext evolutionTestContext)
        {
            _evolutionTestContext = evolutionTestContext;
        }

        public Task<bool> AnyAsync(int id) =>
            _evolutionTestContext.Products.AnyAsync(x => x.Id == id);


        public async Task<Product> CreateAsync(Product entity)
        {
            _evolutionTestContext.Add(entity);
            await _evolutionTestContext.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _evolutionTestContext.Products.OrderBy(x => x.Description).ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _evolutionTestContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task RemoveAsync(Product entity)
        {
            _evolutionTestContext.Remove(entity);
            await _evolutionTestContext.SaveChangesAsync();
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            //_evolutionTestContext.Entry(entity).State = EntityState.Modified;
            _evolutionTestContext.Products.Update(entity);
            await _evolutionTestContext.SaveChangesAsync();
            return entity;
        }
    }
}

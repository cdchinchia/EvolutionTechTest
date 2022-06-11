using EvolutionTechTest.Core.DTO;


namespace EvolutionTechTest.Core.Interfaces
{
    public interface IProductService
    {
        public Task<IEnumerable<ProductDTO>> GetAllAsync();
        public Task<ProductDTO> GetByIdAsync(int id);
        public Task<ProductDTO> CreateAsync(ProductDTO productDTO);
        public Task<ProductDTO> UpdateAsync(int id, ProductDTO productDTO);
        public Task RemoveAsync(int id);
    }
}

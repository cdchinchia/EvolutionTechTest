using EvolutionTechTest.Core.DTO;

namespace EvolutionTechTest.Core.Interfaces
{
    public interface IOrderService
    {
        public Task<IEnumerable<OrderDTO>> GetAllAsync();
        public Task<OrderDTO> GetByIdAsync(int id);
        public Task<OrderDTO> CreateAsync(OrderDTO orderDTO);
        public Task<OrderDTO> UpdateAsync(int id, OrderDTO orderDTO);
        public Task RemoveAsync(int id);
    }
}

using EvolutionTechTest.Core.DTO;

namespace EvolutionTechTest.Core.Interfaces
{
    public interface IUserService
    {
        public Task<IEnumerable<UserDTO>> GetAllAsync();
        public Task<UserDTO> GetByIdAsync(int id);
        public Task<UserDTO> CreateAsync(UserDTO userDTO);
        public Task<UserDTO> UpdateAsync(int id, UserDTO userDTO);
        public Task RemoveAsync(int id);
    }
}

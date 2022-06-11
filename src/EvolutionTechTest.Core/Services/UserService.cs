using AutoMapper;
using EvolutionTechTest.Core.DTO;
using EvolutionTechTest.Core.Entities;
using EvolutionTechTest.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvolutionTechTest.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepositoryAsync<User> _userRepositoryAsync;
        private readonly IMapper _mapper;

        public UserService(IRepositoryAsync<User> userRepositoryAsync, IMapper mapper)
        {
            _userRepositoryAsync = userRepositoryAsync ?? throw new ArgumentNullException(nameof(userRepositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }

        public async Task<UserDTO> CreateAsync(UserDTO userDTO)
        {
            if (userDTO == null) throw new ArgumentNullException();
            User userMapped = _mapper.Map<User>(userDTO);
            await _userRepositoryAsync.CreateAsync(userMapped);
            return userDTO;
        }

        public async Task<IEnumerable<UserDTO>> GetAllAsync()
        {
            IEnumerable<User> users = await _userRepositoryAsync.GetAllAsync();

            IEnumerable<UserDTO> userDTOs = _mapper.Map<List<UserDTO>>(users);
            return userDTOs;
        }

        public async Task<UserDTO> GetByIdAsync(int id)
        {
            User user = await _userRepositoryAsync.GetByIdAsync(id);
            if (user == null) throw new NullReferenceException();
            UserDTO userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public async Task RemoveAsync(int id)
        {
            User user = await _userRepositoryAsync.GetByIdAsync(id);
            if (user == null) throw new NullReferenceException();
            await _userRepositoryAsync.RemoveAsync(user);
        }

        public async Task<UserDTO> UpdateAsync(int id, UserDTO userDTO)
        {
            User user = await _userRepositoryAsync.GetByIdAsync(id);
            if (user == null) throw new NullReferenceException();

            userDTO.Id = id;
            User userMapped = _mapper.Map<User>(userDTO);
            await _userRepositoryAsync.UpdateAsync(userMapped);
            return userDTO;
        }
    }
}

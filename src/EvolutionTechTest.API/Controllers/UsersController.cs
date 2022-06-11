using EvolutionTechTest.Core.DTO;
using EvolutionTechTest.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EvolutionTechTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> Post([FromBody] UserDTO userDTO)
        {
            UserDTO user = await _userService.CreateAsync(userDTO);
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
        {
            IEnumerable<UserDTO> users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> Get([FromRoute] int id)
        {
            UserDTO user = await _userService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<UserDTO>> Update(int id, [FromBody] UserDTO userDTO)
        {
            await _userService.UpdateAsync(id, userDTO);
            return Ok(userDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserDTO>> Delete([FromRoute] int id)
        {
            await _userService.RemoveAsync(id);
            return Ok();
        }
    }
}

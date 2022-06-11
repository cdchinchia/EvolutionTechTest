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
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> Post([FromBody] OrderDTO orderDTO)
        {
            OrderDTO order = await _orderService.CreateAsync(orderDTO);
            return Ok(order);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> Get()
        {
            IEnumerable<OrderDTO> orders = await _orderService.GetAllAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get([FromRoute] int id)
        {
            OrderDTO user = await _orderService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<OrderDTO>> Update(int id, [FromBody] OrderDTO orderDTO)
        {
            OrderDTO order = await _orderService.UpdateAsync(id, orderDTO);
            return Ok(order);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrderDTO>> Delete([FromRoute] int id)
        {
            await _orderService.RemoveAsync(id);
            return Ok();
        }
    }
}

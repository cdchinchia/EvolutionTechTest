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
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> Post([FromBody] ProductDTO productDTO)
        {
            ProductDTO product = await _productService.CreateAsync(productDTO);
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
        {
            IEnumerable<ProductDTO> products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> Get([FromRoute] int id)
        {
            ProductDTO user = await _productService.GetByIdAsync(id);
            return Ok(user);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<ProductDTO>> Update(int id, [FromBody] ProductDTO productDTO)
        {
            ProductDTO product = await _productService.UpdateAsync(id, productDTO);
            return Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductDTO>> Delete([FromRoute] int id)
        {
            await _productService.RemoveAsync(id);
            return Ok();
        }
    }
}

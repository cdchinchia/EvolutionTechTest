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
    public class ProductService : IProductService
    {
        private readonly IRepositoryAsync<Product> _productRepositoryAsync;
        private readonly IMapper _mapper;

        public ProductService(IRepositoryAsync<Product> productRepositoryAsync, IMapper mapper)
        {
            _productRepositoryAsync = productRepositoryAsync ?? throw new ArgumentNullException(nameof(productRepositoryAsync));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

        }
        public async Task<ProductDTO> CreateAsync(ProductDTO productDTO)
        {
            if (productDTO == null) throw new NullReferenceException();
            Product productMapped = _mapper.Map<Product>(productDTO);
            await _productRepositoryAsync.CreateAsync(productMapped);
            return productDTO;
        }

        public async Task<IEnumerable<ProductDTO>> GetAllAsync()
        {
            IEnumerable<Product> products = await _productRepositoryAsync.GetAllAsync();

            IEnumerable<ProductDTO> productDTOs = _mapper.Map<List<ProductDTO>>(products);
            return productDTOs;
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            Product product = await _productRepositoryAsync.GetByIdAsync(id);
            if (product == null) throw new NullReferenceException();
            ProductDTO productDTO = _mapper.Map<ProductDTO>(product);
            return productDTO;
        }

        public async Task RemoveAsync(int id)
        {
            Product product = await _productRepositoryAsync.GetByIdAsync(id);
            if (product == null) throw new NullReferenceException();
            await _productRepositoryAsync.RemoveAsync(product);
        }

        public async Task<ProductDTO> UpdateAsync(int id, ProductDTO productDTO)
        {
            Product product = await _productRepositoryAsync.GetByIdAsync(id);
            if (product == null || productDTO == null) throw new NullReferenceException();

            //productDTO.Id = id;
            Product productMapped = _mapper.Map<Product>(productDTO);
            await _productRepositoryAsync.UpdateAsync(productMapped);
            return productDTO;
        }
    }
}

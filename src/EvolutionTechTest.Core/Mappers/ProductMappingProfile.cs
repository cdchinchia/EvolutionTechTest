using AutoMapper;
using EvolutionTechTest.Core.DTO;
using EvolutionTechTest.Core.Entities;

namespace EvolutionTechTest.Core.Mappers
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDTO>().ReverseMap();
        }

    }
}

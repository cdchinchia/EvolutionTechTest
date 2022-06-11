using AutoMapper;
using EvolutionTechTest.Core.DTO;
using EvolutionTechTest.Core.Entities;

namespace EvolutionTechTest.Core.Mappers
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderDTO>().ReverseMap();
        }

    }
}

using AutoMapper;

namespace EvolutionTechTest.Infrastructure.Helpers.Interfaces
{
    public class IInfraestructureMappers : Mapper
    {
        public IInfraestructureMappers(MapperConfiguration mapperConfiguration) : base(mapperConfiguration)
        {
        }
    }
}

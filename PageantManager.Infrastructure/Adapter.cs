using AutoMapper;
using PageantManager.Core.Interfaces;

namespace PageantManager.Infrastructure
{
    public class Adapter : IAdapter
    {
        private readonly IMapper _mapper;

        public Adapter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TDestination Map<TDestination>(object source)
        {
            return _mapper.Map<TDestination>(source);
        }
    }
}
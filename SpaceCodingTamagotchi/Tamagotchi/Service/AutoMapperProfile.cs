using AutoMapper;
using Tamagotchi.Model;

namespace Tamagotchi.Service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<PokemonDetailsResult, TamagotchiDto>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Altura, opt => opt.MapFrom(src => src.Height))
                .ForMember(dest => dest.Peso, opt => opt.MapFrom(src => src.Weight))
                .ForMember(dest => dest.Habilidades, opt => opt.MapFrom(src => src.Abilities.Select(a => new Habilidade { Nome = a.Ability.Name })));
        }
    }

    public class MascoteService
    {
        private readonly IMapper _mapper;

        public MascoteService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TamagotchiDto CriarMascote(PokemonDetailsResult pokemon)
        {
            return _mapper.Map<TamagotchiDto>(pokemon);
        }
    }

}

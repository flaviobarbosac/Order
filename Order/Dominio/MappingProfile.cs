using AutoMapper;
using Order.Dominio.Dto;

namespace Order.Dominio
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<ProdutoDto, Produto>();
            CreateMap<ClienteDto, Cliente>();
            CreateMap<OrdemDto, Ordem>();
            CreateMap<ItemOrdemDto, ItemOrdem>();            
        }
    }
}

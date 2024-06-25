using AutoMapper;
using Order.Dominio.Dto;

namespace Order.Dominio
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDto, User>();
        }
    }
}

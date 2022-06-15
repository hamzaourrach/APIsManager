using Entities.DataTransferObjects;
using Entities.Models;
using AutoMapper;

namespace APIsManagerApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserForCreationDto, User>();
            CreateMap<UserForUpdateDto, User>();
            //CreateMap<LoginDto, User>();
        }
    }
}

using AutoMapper;
using Common.Domain.Models.Users;
using Core.Domain.Entities;
using Core.Domain.Enums;

namespace Common.API.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<UserRegisterModel, User>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => UserStatus.Active))
                .ForMember(dest => dest.UpdatedDate, opt => opt.MapFrom(src => DateTime.Now.Ticks))
                .ForMember(dest => dest.CreatedDate, opt => opt.MapFrom(src => DateTime.Now.Ticks));
        }
    }
}

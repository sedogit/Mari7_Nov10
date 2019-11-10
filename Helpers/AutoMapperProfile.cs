using AutoMapper;
using Mari7.Entities;
using Mari7.Models;

namespace Mari7.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MariUser, UserModel>();
            CreateMap<RegisterModel, MariUser>();
            CreateMap<UpdateModel, MariUser>();
        }
    }
}
using Agency.Models;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace Agency.Profiles
{
    public class ModelUserProfile:Profile
    {
        public ModelUserProfile()
        {
            CreateMap<UserDTO, ModelUser>().ReverseMap();
            CreateMap<UserDTO, ModelUserForSignUp>().ReverseMap();
            CreateMap<ApplicationUser, ModelUserForSignUp>().ReverseMap();
            CreateMap<ApplicationUser, ModelUser>().ReverseMap();
        }           

    }
}

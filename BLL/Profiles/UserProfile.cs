using AutoMapper;
using BLL.DTO;
using DAL.Entities;


namespace BLL.Profiles
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<UserDTO, ApplicationUser>().ReverseMap();
        }
    }
}

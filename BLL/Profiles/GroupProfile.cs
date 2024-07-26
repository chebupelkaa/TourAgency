using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Profiles
{
    public class GroupProfile:Profile
    {
        public GroupProfile()
        {
            CreateMap<GroupDTO, Group>().ReverseMap();
        }
    }
}

using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Profiles
{
    public class GroupMemberProfile : Profile
    {
        public GroupMemberProfile()
        {
            CreateMap<GroupMemberDTO, GroupMember>().ReverseMap();
        }
    }
}

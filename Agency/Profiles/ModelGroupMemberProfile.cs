using Agency.Models;
using AutoMapper;
using BLL.DTO;

namespace Agency.Profiles
{
    public class ModelGroupMemberProfile:Profile
    {
        public ModelGroupMemberProfile()
        {
            CreateMap<GroupMemberDTO, ModelGroupMember>().ReverseMap();
        }
    }
}

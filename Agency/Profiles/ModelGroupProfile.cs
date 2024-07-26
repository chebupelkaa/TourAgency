using Agency.Models;
using AutoMapper;
using BLL.DTO;

namespace Agency.Profiles
{
    public class ModelGroupProfile:Profile
    {
        public ModelGroupProfile()
        {
            CreateMap<GroupDTO, ModelGroup>().ReverseMap();
        }
    }
}

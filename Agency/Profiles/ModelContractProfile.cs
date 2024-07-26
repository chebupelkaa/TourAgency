using Agency.Models;
using AutoMapper;
using BLL.DTO;

namespace Agency.Profiles
{
    public class ModelContractProfile:Profile
    {
        public ModelContractProfile()
        {
            CreateMap<ContractDTO, ModelContract>().ReverseMap();
        }
    }
}

using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Profiles
{
    public class ContractProfile:Profile
    {
        public ContractProfile()
        {
            CreateMap<ContractDTO, Contract>().ReverseMap();
        }
    }
}

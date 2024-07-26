using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Profiles
{
    public class TourProfile:Profile
    {
        public TourProfile()
        {
            CreateMap<TourDTO, Tour>().ReverseMap();
        }
    }
}

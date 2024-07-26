using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Profiles
{
    public class ReservationProfile:Profile
    {
        public ReservationProfile()
        {
            CreateMap<ReservationDTO, Reservation>().ReverseMap();
        }
    }
}

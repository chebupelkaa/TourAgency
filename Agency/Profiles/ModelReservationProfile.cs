using Agency.Models;
using AutoMapper;
using BLL.DTO;

namespace Agency.Profiles
{
    public class ModelReservationProfile:Profile
    {
        public ModelReservationProfile()
        {
            CreateMap<ReservationDTO, ModelReservation>().ReverseMap();
        }
    }
}

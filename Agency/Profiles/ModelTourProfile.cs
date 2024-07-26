using Agency.Models;
using AutoMapper;
using BLL.DTO;

namespace Agency.Profiles
{
    public class ModelTourProfile:Profile
    {
        public ModelTourProfile()
        {
            CreateMap<TourDTO, ModelTour>().ReverseMap();
        }

    }
}

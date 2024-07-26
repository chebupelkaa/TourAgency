using Agency.Models;
using AutoMapper;
using BLL.DTO;

namespace Agency.Profiles
{
    public class ModelReviewProfile:Profile
    {
        public ModelReviewProfile()
        {
            CreateMap<ReviewDTO, ModelReview>().ReverseMap();
        }
    }
}

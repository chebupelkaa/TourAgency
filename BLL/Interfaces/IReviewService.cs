using BLL.DTO;
namespace BLL.Interfaces
{
    public interface IReviewService : IService<ReviewDTO>
    {
        Task<IEnumerable<ReviewDTO>> FindReviewsForTour(int tourId);
    }
}

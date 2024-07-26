using BLL.DTO;

namespace BLL.Interfaces
{
    public interface ITourService : IService<TourDTO>
    {
        Task<IEnumerable<TourDTO>> SearchToursAsync(string departureCountry, string arrivalCountry, DateTime startDate, int numberOfNights);
        Task<IEnumerable<TourDTO>> SearchTours(DateTime startDate, string arrivalCountry);
        Task<TourDTO> GetTourByReservationId(int reservationsId);
    }
}

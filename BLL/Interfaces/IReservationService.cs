using BLL.DTO;
namespace BLL.Interfaces
{
    public interface IReservationService : IService<ReservationDTO>
    {
        public Task<IEnumerable<ReservationDTO>> FindReservationsByUserId(string userId);
    }
}

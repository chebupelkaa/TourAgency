namespace Agency.Models
{
    public class ModelContract
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public DateTime DateOfSubscribe { get; set; }
        public ModelReservation Reservation { get; set; } = new();
    }
}

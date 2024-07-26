namespace Agency.Models
{
    public class ModelReservation
    {

        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ModelUser ApplicationUser { get; set; } = new();
        public int TourId { get; set; }
        public ModelTour Tour { get; set; } = new();
        public DateTime DateOfReservation { get; set; }
        public string Status { get; set; } = String.Empty;
        public double SumOfPayment { get; set; }
    }
}

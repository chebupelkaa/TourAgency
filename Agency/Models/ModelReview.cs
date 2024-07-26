namespace Agency.Models
{
    public class ModelReview
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string ApplicationUserId { get; set; }
        public ModelUser ApplicationUser { get; set; } = new();
        public ModelTour Tour{ get; set; } = new();
        public int Rating { get; set; }
        public string ReviewText { get; set; } = String.Empty;
        public DateTime ReviewDate { get; set; }
        
    }
}

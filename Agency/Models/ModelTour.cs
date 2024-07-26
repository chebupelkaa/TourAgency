namespace Agency.Models
{
    public class ModelTour
    {
        public int Id { get; set; }
        public string Description { get; set; } = String.Empty;
        public string Pictures { get; set; } = String.Empty;
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfNights { get; set; }
        public string DepartureCountry { get; set; } = String.Empty;
        public string ArrivalCountry { get; set; } = String.Empty;
        public int NumberOfParticipants { get; set; }

    }
}

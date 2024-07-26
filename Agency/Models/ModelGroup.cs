namespace Agency.Models
{
    public class ModelGroup
    {
        public int Id { get; set; }
        public int NumberOfParticipants { get; set; }
        public int TourId { get; set; }
        public ModelTour Tour { get; set; } = new();
        public List<ModelGroupMember> GroupMembers { get; set; } = new();
    }
}

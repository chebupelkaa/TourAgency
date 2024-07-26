namespace Agency.Models
{
    public class ModelGroupMember
    {
        public int Id { get; set; }
        public int GroupId { get; set; }

        public ModelGroup Group { get; set; } = new();
        public ModelUser ApplicationUser { get; set; } = new();
    }
}

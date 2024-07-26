using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public int NumberOfParticipants { get; set; }
        public int TourId { get; set; }
        public Tour Tour { get; set; } = new();
        public List<GroupMember> GroupMembers { get; set; } = new();
    }
}

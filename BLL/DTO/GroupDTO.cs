using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class GroupDTO
    {
        public int Id { get; set; }
        public int NumberOfParticipants { get; set; }
        public int TourId { get; set; }
        public TourDTO Tour { get; set; } = new();
        public List<GroupMemberDTO> GroupMembers { get; set; } = new();

    }
}

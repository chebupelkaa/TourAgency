using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class GroupMember
    {
        public int Id { get; set; }
        public int GroupId { get; set; }

        public Group Group { get; set; } = new();
        public ApplicationUser? ApplicationUser { get; set; } = new();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class GroupMemberDTO
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public string ApplicationUserId { get; set; }
        public UserDTO? ApplicationUser { get; set; } = new();

    }
}

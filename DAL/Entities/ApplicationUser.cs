using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class ApplicationUser:IdentityUser
    {
        public string Surname { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public string Login { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
        public List<GroupMember> GroupMembers { get; set; } = new();
        public List<Reservation> Reservations { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class UserDTO
    {
        //public int Id { get; set; }
        //public string Id { get; set; }
        public string Surname { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public string Login { get; set; } = String.Empty;
        public string Password { get; set; } = String.Empty;
    }
}

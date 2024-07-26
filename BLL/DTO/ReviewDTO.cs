using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ReviewDTO
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public string ApplicationUserId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; } = String.Empty;
        public DateTime ReviewDate { get; set; }
        public UserDTO ApplicationUser { get; set; } = new();
        public TourDTO Tour { get; set; } = new();
    }
}

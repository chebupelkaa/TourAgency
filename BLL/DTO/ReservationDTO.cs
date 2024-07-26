using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ReservationDTO
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }

        public UserDTO ApplicationUser { get; set; } = new();
        public TourDTO Tour { get; set; }
        public int TourId { get; set; }
        public DateTime DateOfReservation { get; set; }
        public string Status { get; set; } = String.Empty;
        public double SumOfPayment { get; set; }
    }
}

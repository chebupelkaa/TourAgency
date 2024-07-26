using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public DateTime DateOfReservation { get; set; }
        public string Status { get; set; } = String.Empty;
        public double SumOfPayment { get; set; }

        //public string ApplicationUserId { get; set; } //убрать при использовании миграций
        public List<Contract> Contracts { get; set; } = new();
        public ApplicationUser? ApplicationUser { get; set; } = new();
        public Tour Tour { get; set; } = new();
    }
}

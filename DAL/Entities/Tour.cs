using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Tour
    {
        public int Id { get; set; }
        public string Description { get; set; } = String.Empty;
        public string Pictures { get; set; } = String.Empty;
        public double Price { get; set; }
        public DateTime StartDate { get; set; }
        public int NumberOfNights { get; set; }
        public string DepartureCountry { get; set; } = String.Empty;
        public string ArrivalCountry { get; set; } = String.Empty;
        public int NumberOfParticipants { get; set; }
        public List<Group> Groups { get; set; } = new();
        public List<Reservation> Reservations { get; set; }= new();
        public List<Review> Reviews { get; set; }= new();

    }
}

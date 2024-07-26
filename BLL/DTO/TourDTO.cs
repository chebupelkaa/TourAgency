using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class TourDTO
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
    }
}

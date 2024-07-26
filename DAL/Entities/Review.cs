using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Review
    {
        public int Id { get; set; }
        public int TourId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }=String.Empty;
        public DateTime ReviewDate { get; set; }
        public ApplicationUser? ApplicationUser { get; set; } = new();
        public Tour Tour { get; set; } = new();
    }
}

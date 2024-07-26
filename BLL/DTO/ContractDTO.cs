using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ContractDTO
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }

        public DateTime DateOfSubscribe { get; set; }
    }
}

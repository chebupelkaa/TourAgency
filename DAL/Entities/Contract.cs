using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Contract
    {
        public int Id { get; set; }
        public int ReservationId { get; set; }
        public DateTime DateOfSubscribe { get; set; }
        public Reservation Reservation { get; set; }=new(); //навигационное свойство для создания связей для получения данных

    }
}

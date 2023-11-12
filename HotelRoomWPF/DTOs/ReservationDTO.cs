using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomWPF.DTOs
{
    public class ReservationDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string FloorNumber { get; set; }
        public string RoomNumber { get; set; }
        public string UserName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}

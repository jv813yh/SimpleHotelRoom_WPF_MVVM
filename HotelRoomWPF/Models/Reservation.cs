using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomWPF.Models
{
    public class Reservation
    {
        public RoomID RoomID { get; set; }
        public string UserName { get; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public TimeSpan Length => EndTime.Subtract(StartTime);

        public Reservation(RoomID roomID, string userName, DateTime startTime, DateTime endTime)
        {
            RoomID = roomID;
            UserName = userName;
            StartTime = startTime;   
            EndTime = endTime;
        }

        public bool Conflicts(Reservation reservation)
        {
            return this.RoomID.Equals(reservation.RoomID) &&
                   (reservation.StartTime < this.EndTime && reservation.EndTime > this.StartTime);
        }

    }
}

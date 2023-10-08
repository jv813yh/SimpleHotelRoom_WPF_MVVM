using HotelRoomWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomWPF.ViewModels
{
    public class ReservationViewModel: BaseViewModel
    {
        private Reservation _reservation;
        public RoomID RoomID  => _reservation.RoomID;
        public string UserName => _reservation.UserName;
        public DateTime StartTime => _reservation.StartTime;
        public DateTime EndTime => _reservation.EndTime;

        public ReservationViewModel(Reservation reservation)
        {
            _reservation = reservation;
        }
    }
}

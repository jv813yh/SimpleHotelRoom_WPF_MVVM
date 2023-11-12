using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomWPF.Models
{
    public class Hotel
    {
        private readonly ReservationBook _reservationBook;

        public string Name { get; set; }

        public Hotel(string name, ReservationBook reservationBook)
        {
            _reservationBook = reservationBook;
            Name = name;
        }

        public async Task<IEnumerable<Reservation>> GettAllReservation() => await _reservationBook.GetAllReservation();

        public async Task MakeReservationHotel(Reservation reservation)
        {
           await _reservationBook.AddReservation(reservation);
        }
    }
}

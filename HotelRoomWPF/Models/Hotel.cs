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

        public Hotel(string name)
        {
            _reservationBook = new ReservationBook();
            Name = name;
        }

        public IEnumerable<Reservation> GetReservationBooks(string userName)
        {
            return _reservationBook.GetReservationForUser(userName);
        }

        public void MakeReservationBook(Reservation reservation)
        {
            _reservationBook.AddReservation(reservation);
        }
    }
}

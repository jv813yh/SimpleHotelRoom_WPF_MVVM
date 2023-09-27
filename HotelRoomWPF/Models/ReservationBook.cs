using HotelRoomWPF.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace HotelRoomWPF.Models
{
    public class ReservationBook
    {
        private readonly List<Reservation> _roomsToReservations;

        public ReservationBook()
        {
            _roomsToReservations = new List<Reservation>();
        }


        public IEnumerable<Reservation> GetReservationForUser(string userName)
        {
            return _roomsToReservations.Where(r => r.UserName == userName);
        }

        public void AddReservation(Reservation reservation)
        {
            foreach (Reservation item in _roomsToReservations)
            {
                if(item.Conflicts(reservation))
                {
                    throw new ReservationConflictException(item, reservation);
                }
            }
            _roomsToReservations.Add(reservation);
        }
    }
}

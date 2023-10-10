using HotelRoomWPF.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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


        public IEnumerable<Reservation> GetAllReservation() => _roomsToReservations;

        public void AddReservation(Reservation reservation)
        {
            try
            {
                foreach (Reservation item in _roomsToReservations)
                {
                    if (item.Conflicts(reservation))
                    {
                        throw new ReservationConflictException(item, reservation);
                    }
                }
                _roomsToReservations.Add(reservation);

                MessageBox.Show("Successfully reserved room", "Information",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (ReservationConflictException ex)
            {
                MessageBox.Show("This room is already taken", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

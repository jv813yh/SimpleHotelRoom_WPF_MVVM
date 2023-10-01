using HotelRoomWPF.Exceptions;
using HotelRoomWPF.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HotelRoomWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Hotel hotel = new Hotel("Astoria hotel");

            try
            {
                hotel.MakeReservationBook(new Reservation(
                 new RoomID(1, 3),
                 "Peter Jakab",
                 new DateTime(2000, 1, 1),
                 new DateTime(2000, 1, 5)));

                hotel.MakeReservationBook(new Reservation(
                    new RoomID(1, 4),
                    "Peter Jakab",
                    new DateTime(2000, 1, 1),
                    new DateTime(2000, 1, 4)));
            }
            catch (ReservationConflictException ex)
            {
                MessageBox.Show(ex.Message, "Mas prekryzenu rezervaciu izby");
            }


            IEnumerable<Reservation> reservations = hotel.GettAllReservation();

            base.OnStartup(e);
        }
    }
}

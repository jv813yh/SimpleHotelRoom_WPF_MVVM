using HotelRoomWPF.DbContexts;
using HotelRoomWPF.DTOs;
using HotelRoomWPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomWPF.Services.ReservationProviders
{
    public class DatabaseReservationProvider: IReservationProvider
    {
        private readonly ReservoomDbContextFactory _contextFactory;

        public DatabaseReservationProvider(ReservoomDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task<IEnumerable<Reservation>> GetReservationsAsync()
        {
            using (ReservoomDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<ReservationDTO> reservationDTOs = await context.Reservations.ToListAsync();

                return reservationDTOs.Select(s => MapToReservation(s));
            }
        }

        private static Reservation MapToReservation(ReservationDTO reservation)
        {
            return new Reservation(new RoomID(reservation.FloorNumber, reservation.RoomNumber), 
                reservation.UserName, reservation.StartDate, reservation.EndDate);
        }
    }
}

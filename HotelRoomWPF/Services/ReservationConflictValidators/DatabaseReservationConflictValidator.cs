using HotelRoomWPF.DbContexts;
using HotelRoomWPF.DTOs;
using HotelRoomWPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomWPF.Services.ReservationConflictValidators
{
    public class DatabaseReservationConflictValidator: IReservationConfilictValidator
    {
        private readonly ReservoomDbContextFactory _contextFactory;

        public DatabaseReservationConflictValidator(ReservoomDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<Reservation> GetConflictingReservation(Reservation reservation)
        {
            using(ReservoomDbContext context = _contextFactory.CreateDbContext())
            {
                ReservationDTO reservationDTO = await context.Reservations
                    .Where(r => r.FloorNumber == reservation.RoomID.FloorNumber)
                    .Where(r => r.RoomNumber == reservation.RoomID.RoomNumber)
                    .Where(r => r.StartDate < reservation.EndTime)
                    .Where(r => r.EndDate > reservation.StartTime)
                    .FirstOrDefaultAsync();

                if(reservationDTO == null)
                {
                    return null;
                }

                return ToReservation(reservationDTO);
            }
        }

        private static Reservation ToReservation(ReservationDTO reservation)
        {
            return new Reservation(new RoomID(reservation.FloorNumber, reservation.RoomNumber),
                               reservation.UserName, reservation.StartDate, reservation.EndDate);
        }
    }
}

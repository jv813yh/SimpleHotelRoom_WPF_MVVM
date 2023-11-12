using HotelRoomWPF.DbContexts;
using HotelRoomWPF.DTOs;
using HotelRoomWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomWPF.Services.ReservationCreators
{
    public class DatabaseReservationCreator : IReservationCreator
    {
        private readonly ReservoomDbContextFactory _contextFactory;

        public DatabaseReservationCreator(ReservoomDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }
        public async Task CreateReservation(Reservation reservation)
        {
            using(ReservoomDbContext context = _contextFactory.CreateDbContext())
            {
                ReservationDTO reservationDTO = MapToReservationDTO(reservation);

                context.Reservations.Add(reservationDTO);
                await context.SaveChangesAsync();
            }
        }

        private ReservationDTO MapToReservationDTO(Reservation reservation)
        {
            return new ReservationDTO
            {
                FloorNumber = reservation.RoomID.FloorNumber,
                RoomNumber = reservation.RoomID.RoomNumber,
                UserName = reservation.UserName,
                StartDate = reservation.StartTime,
                EndDate = reservation.EndTime
            };
        }
    }
}

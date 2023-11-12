using HotelRoomWPF.Exceptions;
using HotelRoomWPF.Services.ReservationConflictValidators;
using HotelRoomWPF.Services.ReservationCreators;
using HotelRoomWPF.Services.ReservationProviders;
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
        private readonly IReservationCreator _reservationCreator;
        private readonly IReservationProvider _reservationProvider;
        private readonly IReservationConfilictValidator _reservationConfilictValidator;

        public ReservationBook(IReservationCreator reservationCreator, 
            IReservationProvider reservationProvider, 
            IReservationConfilictValidator reservationConfilictValidator)
        {
            _reservationCreator = reservationCreator;
            _reservationProvider = reservationProvider;
            _reservationConfilictValidator = reservationConfilictValidator;
        }
        public async Task<IEnumerable<Reservation>> GetAllReservation() => await _reservationProvider.GetReservationsAsync();

        public async Task AddReservation(Reservation reservation)
        {
            Reservation conflictingReservation = await _reservationConfilictValidator.GetConflictingReservation(reservation);

            if (conflictingReservation != null)
            {
                throw new ReservationConflictException(conflictingReservation, reservation);
            }

            await _reservationCreator.CreateReservation(reservation);
        }
    }
}

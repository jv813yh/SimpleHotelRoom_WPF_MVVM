using HotelRoomWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomWPF.Services.ReservationConflictValidators
{
    public interface IReservationConfilictValidator
    {
        Task<Reservation> GetConflictingReservation(Reservation reservation);
    }
}

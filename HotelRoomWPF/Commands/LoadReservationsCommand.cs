using HotelRoomWPF.Models;
using HotelRoomWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HotelRoomWPF.Commands
{
    public class LoadReservationsCommand: AsyncCommandBase
    {
        private readonly ReservetionListingViewModel _reservetionListingViewModel;
        private readonly Hotel _hotel;

        public LoadReservationsCommand(ReservetionListingViewModel reservetionListingViewModel, Hotel hotel)
        {
            _reservetionListingViewModel = reservetionListingViewModel;
            _hotel = hotel;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<Reservation> reservations = await _hotel.GettAllReservation();

                _reservetionListingViewModel.UpdateReservations(reservations);
            }
            catch (Exception)
            {

                MessageBox.Show("Failed to load reservations", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

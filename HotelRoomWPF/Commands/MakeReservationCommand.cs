using HotelRoomWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomWPF.ViewModels;
using System.Windows;
using System.ComponentModel;
using HotelRoomWPF.Exceptions;
using HotelRoomWPF.Services;

namespace HotelRoomWPF.Commands
{
    public class MakeReservationCommand : AsyncCommandBase
    {
        private Hotel _hotel;
        private MakeReservetionViewModel _makeReservetionViewModel;
        private NavigationService _navigationService;

        public MakeReservationCommand(MakeReservetionViewModel makeReservetionViewModel, 
            Hotel hotel,
            NavigationService navigationService)
        {
            _hotel = hotel;
            _navigationService = navigationService;
            _makeReservetionViewModel = makeReservetionViewModel;

            _makeReservetionViewModel.PropertyChanged += OnViewPropertyChanged;
        
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_makeReservetionViewModel.FloorNumber) &&
                !string.IsNullOrEmpty(_makeReservetionViewModel.RoomNumber) &&
                !string.IsNullOrEmpty(_makeReservetionViewModel.UserName) && base.CanExecute(parameter);
        }

        public override async Task ExecuteAsync(object? parameter)
        {

            Reservation reservation = new Reservation(
                new RoomID(_makeReservetionViewModel.FloorNumber, _makeReservetionViewModel.RoomNumber),
                _makeReservetionViewModel.UserName,
                _makeReservetionViewModel.StartTime,
                _makeReservetionViewModel.EndTime);

            try
            {
               await _hotel.MakeReservationHotel(reservation);

                _navigationService.Navigate();
            }
            catch (ReservationConflictException)
            {
                MessageBox.Show("This room is already taken", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch(Exception)
            {
                MessageBox.Show("Failed to make reservation", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void OnViewPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(MakeReservetionViewModel.FloorNumber) ||
                               e.PropertyName == nameof(MakeReservetionViewModel.RoomNumber) ||
                                              e.PropertyName == nameof(MakeReservetionViewModel.UserName))
            {
                OnCanExecuteChanged();
            }
        }
    }
}

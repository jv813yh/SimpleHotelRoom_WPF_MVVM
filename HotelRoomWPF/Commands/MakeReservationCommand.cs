using HotelRoomWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomWPF.ViewModels;
using System.Windows;
using System.ComponentModel;

namespace HotelRoomWPF.Commands
{
    public class MakeReservationCommand : CommandBase
    {
        private Hotel _hotel;
        private MakeReservetionViewModel _makeReservetionViewModel;

        public MakeReservationCommand(MakeReservetionViewModel makeReservetionViewModel, Hotel hotel)
        {
            _hotel = hotel;
            _makeReservetionViewModel = makeReservetionViewModel;

            _makeReservetionViewModel.PropertyChanged += OnViewPropertyChanged;
        
        }

        public override bool CanExecute(object? parameter)
        {
            return !string.IsNullOrEmpty(_makeReservetionViewModel.FloorNumber) &&
                !string.IsNullOrEmpty(_makeReservetionViewModel.RoomNumber) &&
                !string.IsNullOrEmpty(_makeReservetionViewModel.UserName) && base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {

            Reservation reservation = new Reservation(
                new RoomID(_makeReservetionViewModel.FloorNumber, _makeReservetionViewModel.RoomNumber),
                _makeReservetionViewModel.UserName,
                _makeReservetionViewModel.StartTime,
                _makeReservetionViewModel.EndTime);

            _hotel.MakeReservationHotel(reservation);
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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelRoomWPF.Commands;
using HotelRoomWPF.Models;
using HotelRoomWPF.Services;
using HotelRoomWPF.Stores;

namespace HotelRoomWPF.ViewModels
{
    public class ReservetionListingViewModel: BaseViewModel
    {
        private Hotel _hotel;
        public ICommand MakeReservationCommand { get; }

        public NavigationService NavigationService { get; }

        private ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> GetAllReservations => _reservations;

        public ReservetionListingViewModel(Hotel hotel, NavigationService navigationService)
        {
            _reservations = new ObservableCollection<ReservationViewModel>();

            MakeReservationCommand = new NavigateCommand(navigationService);
            _hotel = hotel;
            NavigationService = navigationService;

            UpdateReservations();
        }

        private void UpdateReservations()
        {
            _reservations.Clear();

            foreach (var reservation in _hotel.GettAllReservation())
            {
                _reservations.Add(new ReservationViewModel(reservation));
            }
        }
    }
}

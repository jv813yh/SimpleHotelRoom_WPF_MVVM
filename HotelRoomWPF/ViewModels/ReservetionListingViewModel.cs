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
        public ICommand MakeReservationCommand { get; }
        public ICommand LoadReservationCommand { get; }


        private ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> GetAllReservations => _reservations;

        public ReservetionListingViewModel(Hotel hotel, NavigationService navigationService)
        {
            _reservations = new ObservableCollection<ReservationViewModel>();

            MakeReservationCommand = new NavigateCommand(navigationService);
            LoadReservationCommand = new LoadReservationsCommand(this, hotel);

        }
        
        public static ReservetionListingViewModel LoadReservations(Hotel hotel, NavigationService navigationService)
        {
            ReservetionListingViewModel viewModel = new ReservetionListingViewModel(hotel, navigationService);

            viewModel.LoadReservationCommand.Execute(null);

            return viewModel;
        }

        public void UpdateReservations(IEnumerable<Reservation> reservations)
        {
            _reservations.Clear();

            foreach (Reservation reservation in reservations)
            {
                _reservations.Add(new ReservationViewModel(reservation));
            }
        }
    }
}

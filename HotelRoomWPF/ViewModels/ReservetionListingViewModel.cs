using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelRoomWPF.Models;

namespace HotelRoomWPF.ViewModels
{
    public class ReservetionListingViewModel: BaseViewModel
    {
        public ICommand MakeReservationCommand { get; }

        private ObservableCollection<ReservationViewModel> _reservations;

        public IEnumerable<ReservationViewModel> GetAllReservations => _reservations;

        public ReservetionListingViewModel()
        {
            _reservations = new ObservableCollection<ReservationViewModel>();

            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(1, 9), "Dominik Lacko", DateTime.Now, DateTime.Now)));  
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(2, 5), "Juraj Lacko", DateTime.Now, DateTime.Now)));  
            _reservations.Add(new ReservationViewModel(new Reservation(new RoomID(1, 1), "Šimon Lacko", DateTime.Now, DateTime.Now)));  
        }

    }
}

using HotelRoomWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelRoomWPF.Commands;


namespace HotelRoomWPF.ViewModels
{
    public class MakeReservetionViewModel: BaseViewModel
    {
        public MakeReservetionViewModel(Hotel hotel, Stores.NavigationStore navigationStore, Func<ReservetionListingViewModel> createReservetionListingViewModel)
        { 
            SubmitCommand = new MakeReservationCommand(this, hotel);
            CancelCommand = new NavigateCommand(navigationStore, createReservetionListingViewModel);

        } 

        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }


        private string _floorNumber;
        public string FloorNumber 
        {
            get
            {
                return _floorNumber;
            }
            set
            {
                if(_floorNumber != value)
                {
                    _floorNumber = value;
                    OnPropertyChanged(nameof(FloorNumber));
                }
            }
        }
        private string _roomNumber;
        public string RoomNumber
        {
            get
            {
                return _roomNumber;
            }
            set
            {
                if(_roomNumber != value)
                {
                    _roomNumber = value;
                    OnPropertyChanged(nameof(RoomNumber));
                }
            }
        }
        private string _userName;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if(_userName != value)
                {
                    _userName = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }
        private DateTime _startTime;
        public DateTime StartTime 
        {
            get
            {
                return _startTime;
            }
            set
            {
                if(_startTime != value)
                {
                    _startTime = value;
                    OnPropertyChanged(nameof(StartTime));
                }
            }
        }

        private DateTime _endTime;
        public DateTime EndTime
        {
            get
            {
                return _endTime;
            }
            set
            {
                if(_endTime != value)
                {
                    _endTime = value;
                    OnPropertyChanged(nameof(EndTime));
                }
            }
        }
    }
}

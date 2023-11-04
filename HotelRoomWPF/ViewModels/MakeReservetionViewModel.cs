using HotelRoomWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using HotelRoomWPF.Commands;
using HotelRoomWPF.Services;

namespace HotelRoomWPF.ViewModels
{
    public class MakeReservetionViewModel: BaseViewModel
    {
        public MakeReservetionViewModel(Hotel hotel, 
            NavigationService navigationService)
        { 
            SubmitCommand = new MakeReservationCommand(this, hotel, navigationService);
            CancelCommand = new NavigateCommand(navigationService);

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
        private DateTime _startTime = DateTime.Now;
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

        private DateTime _endTime = DateTime.Now;
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

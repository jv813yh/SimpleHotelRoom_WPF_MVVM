using HotelRoomWPF.Services;
using HotelRoomWPF.Stores;
using HotelRoomWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HotelRoomWPF.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly Services.NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }
        public override void Execute(object? parameter)
        {
            _navigationService.Navigate();
        }
    }
}

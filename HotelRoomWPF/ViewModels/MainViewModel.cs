using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomWPF.Models;

namespace HotelRoomWPF.ViewModels
{
    public class MainViewModel
    {
        public BaseViewModel CurrentViewModel { get; }

        public MainViewModel(Hotel hotel)
        {
            CurrentViewModel = new ReservetionListingViewModel();
        }
    }
}

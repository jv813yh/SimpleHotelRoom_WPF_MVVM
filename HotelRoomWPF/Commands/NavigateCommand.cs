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
        private readonly NavigationStore _navigationStore;
        private readonly Func<BaseViewModel> _createViewModel;
        public NavigateCommand(NavigationStore navigationStore, Func<BaseViewModel> createViewModel)
        {
            _navigationStore =  navigationStore;
            _createViewModel = createViewModel;
        }

        public override void Execute(object? parameter)
        {
            _navigationStore.CurrentViewModel = _createViewModel();
        }
   
    }
}

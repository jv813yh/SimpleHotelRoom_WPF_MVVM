using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelRoomWPF.Models;
using HotelRoomWPF.Stores;
using HotelRoomWPF.ViewModels;

namespace HotelRoomWPF.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private readonly NavigationStore _navigationStore;
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}

using HotelRoomWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelRoomWPF.Stores
{
    public class NavigationStore
    {
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel 
        { 
            get => _currentViewModel;
            set
            {
                _currentViewModel = value;
                OnCurrentViewModel();
            }
        }

        private void OnCurrentViewModel()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;

    }
}

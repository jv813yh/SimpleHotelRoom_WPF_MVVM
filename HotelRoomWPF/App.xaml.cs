using HotelRoomWPF.Exceptions;
using HotelRoomWPF.Models;
using HotelRoomWPF.Services;
using HotelRoomWPF.Stores;
using HotelRoomWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HotelRoomWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Hotel _hotel;
        private readonly NavigationStore _navigationStore;

        public App()
        {
            _hotel = new Hotel("White Horse");
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {

            _navigationStore.CurrentViewModel = CreateReservetionListingViewModel();

            MainWindow = new MainWindow()
            {
                DataContext = new ViewModels.MainViewModel(_navigationStore) 
            };

            MainWindow.Show();

            base.OnStartup(e);
        }

        private MakeReservetionViewModel CreateMakeReservationViewModel()
        {
            return new MakeReservetionViewModel(_hotel, new NavigationService( _navigationStore, CreateReservetionListingViewModel));
        }

        private ReservetionListingViewModel CreateReservetionListingViewModel()
        {
            return new ReservetionListingViewModel(_hotel, new NavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }
}

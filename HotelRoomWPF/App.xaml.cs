using HotelRoomWPF.DbContexts;
using HotelRoomWPF.Exceptions;
using HotelRoomWPF.Models;
using HotelRoomWPF.Services;
using HotelRoomWPF.Services.ReservationProviders;
using HotelRoomWPF.Stores;
using HotelRoomWPF.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using HotelRoomWPF.Services.ReservationCreators;
using HotelRoomWPF.Services.ReservationConflictValidators;
using HotelRoomWPF.Services.ReservationProviders;

namespace HotelRoomWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private const string _connectionString = "Data Source=reservoom.db";

        private readonly Hotel _hotel;
        private readonly NavigationStore _navigationStore;
        private readonly ReservoomDbContextFactory _contextFactory;

        public App()
        {
             _contextFactory = new ReservoomDbContextFactory(_connectionString);

            IReservationProvider reservationProvider = new DatabaseReservationProvider(_contextFactory);
            IReservationCreator reservationCreator = new DatabaseReservationCreator(_contextFactory);
            IReservationConfilictValidator reservationConflictValidator = new DatabaseReservationConflictValidator(_contextFactory);

            ReservationBook reservationBook = new ReservationBook(reservationCreator, reservationProvider, reservationConflictValidator);

            _hotel = new Hotel("White Horse", reservationBook);
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {

            using(ReservoomDbContext context = _contextFactory.CreateDbContext())
            {
                context.Database.Migrate();
            }

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
            return ReservetionListingViewModel.LoadReservations(_hotel, new NavigationService(_navigationStore, CreateMakeReservationViewModel));
        }
    }
}

using HotelRoomWPF.Exceptions;
using HotelRoomWPF.Models;
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

        public App()
        {
            _hotel = new Hotel("White Horse");
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new ViewModels.MainViewModel(_hotel) 
            };

            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}

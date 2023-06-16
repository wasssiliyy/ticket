using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ticket.Commands;
using ticket.DataAccess.Concrete;
using ticket.Domain.SqlServer;

namespace ticket.Domain.ViewModels
{
    public class MainWindowViewModel:BaseViewModel
    {
        public RelayCommand PurchaseButton { get; set; }
        public RelayCommand SelectionChanged { get; set; }
        public RelayCommand SelectionChangedSchedules { get; set; }
        public RelayCommand SelectionChangedAirplanes { get; set; }


        private ObservableCollection<Ticket> ticketsItemSource;

        public ObservableCollection<Ticket> TicketsItemSource
        {
            get { return ticketsItemSource; }
            set { ticketsItemSource = value; OnPropertyChanged(); }
        }

        private ObservableCollection<City> citiesItemSource;

        public ObservableCollection<City> CitiesItemSource
        {
            get { return citiesItemSource; }
            set { citiesItemSource = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Schedule> schedulesItemSource;

        public ObservableCollection<Schedule> SchedulesItemSource
        {
            get { return schedulesItemSource; }
            set { schedulesItemSource = value; OnPropertyChanged(); }
        }

        private ObservableCollection<Airplane> airplanesItemSource;

        public ObservableCollection<Airplane> AirplanesItemSource
        {
            get { return airplanesItemSource; }
            set { airplanesItemSource = value; OnPropertyChanged(); }
        }

        private ObservableCollection<FlightType> flightTypeItemSource;

        public ObservableCollection<FlightType> FlightTypeItemSource
        {
            get { return flightTypeItemSource; }
            set { flightTypeItemSource = value; OnPropertyChanged(); }
        }

        private string pilotName;

        public string PilotName
        {
            get { return pilotName; }
            set { pilotName = value; OnPropertyChanged(); }
        }

        private string pilotSurname;

        public string PilotSurname
        {
            get { return pilotSurname; }
            set { pilotSurname = value; OnPropertyChanged(); }
        }

        private bool schedulesIsEnable;

        public bool SchedulesIsEnable
        {
            get { return schedulesIsEnable; }
            set { schedulesIsEnable = value; OnPropertyChanged(); }
        }

        private City citySelectedItem;

        public City CitySelectedItem
        {
            get { return citySelectedItem; }
            set { citySelectedItem = value; OnPropertyChanged(); }
        }

        private Schedule schedule;

        public Schedule ScheduleSelectedItem
        {
            get { return schedule; }
            set { schedule = value; OnPropertyChanged(); }
        }

        private FlightType flightType;

        public FlightType FlightType
        {
            get { return flightType; }
            set { flightType = value; OnPropertyChanged(); }
        }


        private Airplane airplane;

        public Airplane Airplane
        {
            get { return airplane; }
            set { airplane = value; OnPropertyChanged(); }
        }

        private bool _isEnable;

        public bool IsEnable
        {
            get { return _isEnable; }
            set { _isEnable = value;OnPropertyChanged(); }
        }


        private CityRepository _cityRepository = new CityRepository();
        private ScheduleRepository _scheduleRepository = new ScheduleRepository();
        private AirplaneRepository _airplaneRepository =  new AirplaneRepository();
        private PilotRepository _pilotRepository = new PilotRepository();
        private FlightTypesRepository _flightTypesRepository = new FlightTypesRepository();
        private TicketRepository ticketRepository = new TicketRepository();
        public MainWindowViewModel()
        {
            

            if (CitySelectedItem != null)
            {
                SchedulesIsEnable = false;
            }

            CitiesItemSource = _cityRepository.GetAll();


            SelectionChanged = new RelayCommand((obj) =>
            {
                SchedulesIsEnable = true;
                SchedulesItemSource = _scheduleRepository.CityGetAll(CitySelectedItem.Id);
            });

            SelectionChangedSchedules = new RelayCommand((obj) =>
            {
                try
                {
                    AirplanesItemSource = _airplaneRepository.GetDataByScheduleId(ScheduleSelectedItem.Id);
                    IsEnable=true;
                }
                catch (Exception)
                {
                }
            });

            SelectionChangedAirplanes = new RelayCommand((obj) =>
            {
                var pilot = _pilotRepository.GetData((int)Airplane.PilotId);
                PilotName = pilot.Name;
                PilotSurname = pilot.Surname;
            });

            FlightTypeItemSource = _flightTypesRepository.GetAll();

            var tickets = ticketRepository.GetAll();

            TicketsItemSource = tickets;


            PurchaseButton = new RelayCommand((obj) =>
            {
                Ticket ticket = new Ticket();
                ticket.FlightTypeId = FlightType.Id;

                ticket.AirplaneId = Airplane.Id;

                ticket.ScheduleId = ScheduleSelectedItem.Id;

                ticketRepository.AddData(ticket);

                var gettickets = ticketRepository.GetAll();

                TicketsItemSource = gettickets;

                MessageBox.Show("Successfully");
            });
        }
    }
}

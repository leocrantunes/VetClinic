using System;
using System.Collections.ObjectModel;
using System.Linq;
using VetClinic.Wpf.Core;
using VetClinic.Wpf.Model;
using VetClinic.Wpf.Model.Enum;

namespace VetClinic.Wpf.ViewModel
{
    public class AppointmentDialogViewModel : BaseNotifyPropertyChanged
    {
        private const int SlotTimeBeginning = 9;
        private const int SlotLength = 8;
        private const int SlotSize = 1;

        public AppointmentDialogViewModel(Schedule schedule, ObservableCollection<Pet> registeredPets, Appointment appointment = null)
        {
            Message = string.Empty;
            Appointment = appointment == null ? new Appointment() : new Appointment(appointment, registeredPets.FirstOrDefault(p => p.Id == appointment.Patient?.Id));
            Schedule = schedule;
            RegisteredPets = registeredPets;

            Places = new ObservableCollection<AppointmentPlace>(Enum.GetValues(typeof(AppointmentPlace)).Cast<AppointmentPlace>());
            ServiceTypes = new ObservableCollection<ServiceType>(Enum.GetValues(typeof(ServiceType)).Cast<ServiceType>());

            PossibleHours = new ObservableCollection<TimeSpan>();
            SetPossibleHours();
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set
            {
                _message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private Appointment _appointment;
        public Appointment Appointment
        {
            get { return _appointment; }
            set
            {
                _appointment = value;
                OnPropertyChanged(nameof(Appointment));
            }
        }

        private Schedule _schedule;
        public Schedule Schedule
        {
            get { return _schedule; }
            set
            {
                _schedule = value;
                OnPropertyChanged(nameof(Schedule));
            }
        }

        public ObservableCollection<Pet> RegisteredPets { get; set; }

        public ObservableCollection<AppointmentPlace> Places { get; set; }

        public ObservableCollection<ServiceType> ServiceTypes { get; set; }

        public ObservableCollection<TimeSpan> PossibleHours { get; private set; }

        public bool CheckFields()
        {
            Message = string.Empty;

            return true;
        }

        private void SetPossibleHours()
        {
            PossibleHours.Clear();
            for (int i = 0; i < SlotLength; i++)
            {
                PossibleHours.Add(TimeSpan.FromHours(SlotTimeBeginning + i * SlotSize));
            }
        }
    }
}

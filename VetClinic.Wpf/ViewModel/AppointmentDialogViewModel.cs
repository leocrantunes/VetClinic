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
        public AppointmentDialogViewModel(ObservableCollection<Pet> registeredPets)
        {
            Message = string.Empty;
            Schedule = new Schedule();
            RegisteredPets = registeredPets;

            Place = new ObservableCollection<AppointmentPlace>(Enum.GetValues(typeof(AppointmentPlace)).Cast<AppointmentPlace>());
            TypeofService = new ObservableCollection<ServiceType>(Enum.GetValues(typeof(ServiceType)).Cast<ServiceType>());
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

        public ObservableCollection<AppointmentPlace> Place { get; set; }

        public ObservableCollection<ServiceType> TypeofService { get; set; }

        public bool CheckFields()
        {
            Message = string.Empty;

            return true;
        }
    }
}

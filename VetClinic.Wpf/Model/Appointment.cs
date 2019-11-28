using System;
using VetClinic.Wpf.Core;
using VetClinic.Wpf.Model.Enum;

namespace VetClinic.Wpf.Model
{
    public class Appointment : BaseNotifyPropertyChanged
    {
        public Appointment()
        {
            Patient = new Pet();
            DateTime = DateTime.Today;
            AppointmentPlace = null;
            ServiceType = null;
        }
        
        private Pet _patient;
        public Pet Patient
        {
            get { return _patient; }
            set
            {
                _patient = value;
                OnPropertyChanged(nameof(Patient));
            }
        }

        private DateTime _dateTime;
        public DateTime DateTime
        {
            get { return _dateTime; }
            set
            {
                _dateTime = value;
                OnPropertyChanged(nameof(DateTime));
            }
        }
        
        private AppointmentPlace? _appointmentPlace;
        public AppointmentPlace? AppointmentPlace
        {
            get { return _appointmentPlace; }
            set
            {
                _appointmentPlace = value;
                OnPropertyChanged(nameof(AppointmentPlace));
            }
        }

        private ServiceType? _serviceType;
        public ServiceType? ServiceType
        {
            get { return _serviceType; }
            set
            {
                _serviceType = value;
                OnPropertyChanged(nameof(ServiceType));
            }
        }
    }
}
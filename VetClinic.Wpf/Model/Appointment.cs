using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Serialization;
using VetClinic.Wpf.Core;
using VetClinic.Wpf.Model.Enums;

namespace VetClinic.Wpf.Model
{
    public class Appointment : BaseNotifyPropertyChanged
    {
        public Appointment()
        {
            Id = string.Empty;
            Patient = new Pet();
            Date = null;
            Time = TimeSpan.FromHours(12);
            Place = null;
            ServiceType = null;
            IsVisible = true;
        }

        public Appointment(Appointment appointment, Pet patient)
        {
            Id = appointment.Id;
            Patient = patient;
            Date = appointment.Date;
            Time = appointment.Time;
            Place = appointment.Place;
            ServiceType = appointment.ServiceType;
            IsVisible = true;
        }

        private string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
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

        private DateTime? _date;
        public DateTime? Date
        {
            get { return _date; }
            set
            {
                _date = value;
                OnPropertyChanged(nameof(Date));
            }
        }

        private TimeSpan _time;
        [XmlIgnore]
        public TimeSpan Time
        {
            get { return _time; }
            set
            {
                _time = value;
                OnPropertyChanged(nameof(Time));
            }
        }
        
        [XmlElement("Time")]
        public long TimeTicks
        {
            get { return _time.Ticks; }
            set { _time = new TimeSpan(value); }
        }

        private AppointmentPlace? _appointmentPlace;
        public AppointmentPlace? Place
        {
            get { return _appointmentPlace; }
            set
            {
                _appointmentPlace = value;
                OnPropertyChanged(nameof(Place));
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

        private bool _isVisible;
        public bool IsVisible
        {
            get { return _isVisible; }
            set
            {
                _isVisible = value;
                OnPropertyChanged(nameof(IsVisible));
            }
        }
    }
}
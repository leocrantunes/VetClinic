using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.Wpf.Core;
using VetClinic.Wpf.Model.Enums;

namespace VetClinic.Wpf.Model.Filters
{
    public class AppointmentFilters : BaseNotifyPropertyChanged
    {
        public AppointmentFilters()
        {
            Reset();

            PetTypes = new ObservableCollection<PetType>(Enum.GetValues(typeof(PetType)).Cast<PetType>());
            ServiceTypes = new ObservableCollection<ServiceType>(Enum.GetValues(typeof(ServiceType)).Cast<ServiceType>());
        }

        private bool _isNameSelected;
        public bool IsNameSelected
        {
            get { return _isNameSelected; }
            set
            {
                _isNameSelected = value;
                OnPropertyChanged(nameof(IsNameSelected));
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private bool _isDateFromSelected;
        public bool IsDateFromSelected
        {
            get { return _isDateFromSelected; }
            set
            {
                _isDateFromSelected = value;
                OnPropertyChanged(nameof(IsDateFromSelected));
            }
        }

        private DateTime _dateFrom;
        public DateTime DateFrom
        {
            get { return _dateFrom; }
            set
            {
                _dateFrom = value;
                OnPropertyChanged(nameof(DateFrom));
            }
        }

        private bool _isDateToSelected;
        public bool IsDateToSelected
        {
            get { return _isDateToSelected; }
            set
            {
                _isDateToSelected = value;
                OnPropertyChanged(nameof(IsDateToSelected));
            }
        }

        private DateTime _dateTo;
        public DateTime DateTo
        {
            get { return _dateTo; }
            set
            {
                _dateTo = value;
                OnPropertyChanged(nameof(DateTo));
            }
        }

        private bool _isPetTypeSelected;
        public bool IsPetTypeSelected
        {
            get { return _isPetTypeSelected; }
            set
            {
                _isPetTypeSelected = value;
                OnPropertyChanged(nameof(IsPetTypeSelected));
            }
        }

        private PetType? _type;
        public PetType? PetType
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(PetType));
            }
        }

        private bool _isServiceTypeSelected;
        public bool IsServiceTypeSelected
        {
            get { return _isServiceTypeSelected; }
            set
            {
                _isServiceTypeSelected = value;
                OnPropertyChanged(nameof(IsServiceTypeSelected));
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

        public ObservableCollection<PetType> PetTypes { get; set; }

        public ObservableCollection<ServiceType> ServiceTypes { get; set; }

        public void Reset()
        {
            IsNameSelected = false;
            Name = string.Empty;
            IsDateFromSelected = false;
            DateFrom = DateTime.Today.AddDays(-15);
            IsDateToSelected = false;
            DateTo = DateTime.Today.AddDays(30);
            IsPetTypeSelected = false;
            PetType = null;
            IsServiceTypeSelected = false;
            ServiceType = null;
        }
    }
}

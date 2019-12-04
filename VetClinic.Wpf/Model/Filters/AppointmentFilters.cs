using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.Wpf.Core;

namespace VetClinic.Wpf.Model.Filters
{
    public class AppointmentFilters : BaseNotifyPropertyChanged
    {
        public AppointmentFilters()
        {
            IsNameSelected = true;
            Name = string.Empty;
            IsDateFromSelected = true;
            DateFrom = DateTime.Today;
            IsDateToSelected = true;
            DateTo = DateTime.Today.AddDays(15);
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

        public void Reset()
        {
            IsNameSelected = true;
            Name = string.Empty;
            IsDateFromSelected = true;
            DateFrom = DateTime.Today;
            IsDateToSelected = true;
            DateTo = DateTime.Today.AddDays(15);
        }
    }
}

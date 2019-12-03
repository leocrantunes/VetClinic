using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Wpf.Model
{
    public class Schedule
    {
        public Schedule()
        {
            Appointments = new ObservableCollection<Appointment>();
        }

        public ObservableCollection<Appointment> Appointments { get; set; }
    }
}
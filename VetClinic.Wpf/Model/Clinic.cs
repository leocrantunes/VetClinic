using System.Collections.ObjectModel;
using VetClinic.Wpf.Core;

namespace VetClinic.Wpf.Model
{
    public class Clinic : BaseNotifyPropertyChanged
    {
        public Clinic()
        {
            Schedule = new Schedule();
            Patients = new ObservableCollection<Pet>();
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

        public ObservableCollection<Pet> Patients { get; set; }

        public void Clear()
        {
            Patients?.Clear();
            Schedule?.Appointments?.Clear();
        }
    }
}
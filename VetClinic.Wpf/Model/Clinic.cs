using System.Collections.ObjectModel;
using VetClinic.Wpf.Core;

namespace VetClinic.Wpf.Model
{
    public class Clinic : BaseNotifyPropertyChanged
    {
        public Clinic()
        {
            Patients = new ObservableCollection<Pet>();
        }

        public ObservableCollection<Pet> Patients { get; set; }

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

        public void Clear()
        {
            Patients?.Clear();
        }
    }
}
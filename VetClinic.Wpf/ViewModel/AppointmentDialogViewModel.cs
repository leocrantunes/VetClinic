using System.Collections.ObjectModel;
using VetClinic.Wpf.Core;
using VetClinic.Wpf.Model;

namespace VetClinic.Wpf.ViewModel
{
    public class AppointmentDialogViewModel : BaseNotifyPropertyChanged
    {
        public AppointmentDialogViewModel(ObservableCollection<Pet> registeredPets)
        {
            Message = string.Empty;
            Schedule = new Schedule();
            RegisteredPets = registeredPets;
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

        public bool CheckFields()
        {
            Message = string.Empty;

            return true;
        }
    }
}

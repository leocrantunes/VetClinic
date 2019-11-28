using System.Collections.ObjectModel;

namespace VetClinic.Wpf.Model
{
    public class Clinic
    {
        public Clinic()
        {
            Patients = new ObservableCollection<Pet>();
        }

        public ObservableCollection<Pet> Patients { get; set; }

        public void Clear()
        {
            Patients?.Clear();
        }
    }
}

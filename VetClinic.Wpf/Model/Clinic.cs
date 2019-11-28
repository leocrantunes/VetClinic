using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

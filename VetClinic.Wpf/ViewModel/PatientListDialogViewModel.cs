using System;
using System.Collections.ObjectModel;
using System.Linq;
using VetClinic.Wpf.Core;
using VetClinic.Wpf.Model;
using VetClinic.Wpf.Model.Enum;

namespace VetClinic.Wpf.ViewModel
{
    public class PatientListDialogViewModel : BaseNotifyPropertyChanged
    {

        public PatientListDialogViewModel(ObservableCollection<Pet> registeredPets)
        {
            RegisteredPets = registeredPets;

        }

        public ObservableCollection<Pet> RegisteredPets { get; set; }


        // create editpatient and removepatient method

        /*public void EditPatient(Appointment oldAppointment, Appointment newAppointment)
        {
            //var index = VetClinic.Schedule.Appointments.IndexOf(oldAppointment);
            //VetClinic.Schedule.Appointments[index] = newAppointment;
        }

        /// <summary>
        /// Remove appointment
        /// </summary>
        /// <param name="appointment"></param>
        public void RemovePatient(Appointment appointment)
        {
            // review algorithm
            //VetClinic.Schedule.Appointments.Remove(appointment);
        }*/
    }

}

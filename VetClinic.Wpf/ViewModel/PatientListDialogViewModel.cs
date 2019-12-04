using System.Collections.ObjectModel;
using VetClinic.Wpf.Core;
using VetClinic.Wpf.Model;

namespace VetClinic.Wpf.ViewModel
{
    public class PatientListDialogViewModel : BaseNotifyPropertyChanged
    {
        public PatientListDialogViewModel(MainWindowViewModel mainWindowViewModel)
        {
            MainWindowViewModel = mainWindowViewModel;
        }

        public MainWindowViewModel MainWindowViewModel { get; set; }

        public void EditPatient(Pet oldPatient, Pet newPatient)
        {
            MainWindowViewModel.EditPatient(oldPatient, newPatient);
        }

        /// <summary>
        /// Remove patient
        /// </summary>
        /// <param name="patient"></param>
        public void RemovePatient(Pet patient)
        {
            MainWindowViewModel.RemovePatient(patient);
        }
    }
}

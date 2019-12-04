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

        /// <summary>
        /// 
        /// </summary>
        public MainWindowViewModel MainWindowViewModel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="newPatient"></param>
        public void EditPatient(Pet newPatient)
        {
            MainWindowViewModel.EditPatient(newPatient);
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

using System;
using System.Collections.ObjectModel;
using System.Linq;
using VetClinic.Wpf.Core;
using VetClinic.Wpf.Model;
using VetClinic.Wpf.Model.Enum;

namespace VetClinic.Wpf.ViewModel
{
    public class PatientDialogViewModel : BaseNotifyPropertyChanged
    {
        public PatientDialogViewModel(ObservableCollection<Pet> registeredPets)
        {
            Message = string.Empty;
            Patient = new Pet();
            RegisteredPets = registeredPets;

            Genders = new ObservableCollection<Gender>(Enum.GetValues(typeof(Gender)).Cast<Gender>());
            TypesOfPet = new ObservableCollection<PetType>(Enum.GetValues(typeof(PetType)).Cast<PetType>());
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

        private Pet _patient;
        public Pet Patient
        {
            get { return _patient; }
            set
            {
                _patient = value;
                OnPropertyChanged(nameof(Patient));
            }
        }

        public ObservableCollection<Pet> RegisteredPets { get; set; }

        public ObservableCollection<Gender> Genders { get; set; }

        public ObservableCollection<PetType> TypesOfPet { get; set; }

        public bool CheckFields()
        {
            Message = string.Empty;

            return true;
        }
    }
}

using System;
using System.Collections.ObjectModel;
using System.Linq;
using VetClinic.Wpf.Core;
using VetClinic.Wpf.Model;
using VetClinic.Wpf.Model.Enums;

namespace VetClinic.Wpf.ViewModel
{
    public class PatientDialogViewModel : BaseNotifyPropertyChanged
    {
        public PatientDialogViewModel(ObservableCollection<Pet> registeredPets, Pet patient = null)
        {
            Message = string.Empty;
            Patient = patient == null ? new Pet() : new Pet(patient);

            RegisteredPets = registeredPets;

            Genders = new ObservableCollection<Gender>(Enum.GetValues(typeof(Gender)).Cast<Gender>());
            PetTypes = new ObservableCollection<PetType>(Enum.GetValues(typeof(PetType)).Cast<PetType>());
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

        public ObservableCollection<PetType> PetTypes { get; set; }

        public bool CheckFields()
        {
            Message = string.Empty;

            // check owner
            if (!CheckOwnerFields())
            {
                return false;
            }
            // check pet
            else if (!CheckPetFields())
            {
                return false;
            }

            return true;
        }

        private bool CheckOwnerFields()
        {
            if (string.IsNullOrEmpty(Patient.Owner.FirstName))
            {
                Message = "First name is mandatory";
            }
            else if (string.IsNullOrEmpty(Patient.Owner.LastName))
            {
                Message = "Last name is mandatory";
            }
            else if (string.IsNullOrEmpty(Patient.Owner.Phone))
            {
                Message = "Phone is mandatory";
            }
            else if (Patient.Owner.Phone.Length != 10 || Patient.Owner.Phone.Any(x => !char.IsNumber(x)))
            {
                Message = "Phone must have 10 numeric digits";
            }
            else if (string.IsNullOrEmpty(Patient.Owner.Email))
            {
                Message = "E-mail is mandatory";
            }

            return Message == string.Empty;
        }

        private bool CheckPetFields()
        {
            if (Patient.Type == null)
            {
                Message = "Type of pet is mandatory";
            }
            else if (string.IsNullOrEmpty(Patient.Name))
            {
                Message = "Patient name is mandatory";
            }
            else if (string.IsNullOrEmpty(Patient.Breed))
            {
                Message = "Patient breed is mandatory";
            }
            else if (Patient.Age == null || Patient.Age < 0)
            {
                Message = "Patient age is mandatory and must be greater than or equals to 0 (in case of newborn)";
            }
            else if (Patient.Gender == null)
            {
                Message = "Patient gender is mandatory";
            }
            else if (Patient.Weight != null && Patient.Weight <= 0)
            {
                Message = "Patient weight must be greater than 0";
            }
            else if (Patient.Length != null && Patient.Length <= 0)
            {
                Message = "Patient length must be greater than 0";
            }
            else if (Patient.Height != null && Patient.Height <= 0)
            {
                Message = "Patient height must be greater than 0";
            }

            return Message == string.Empty;
        }
    }
}

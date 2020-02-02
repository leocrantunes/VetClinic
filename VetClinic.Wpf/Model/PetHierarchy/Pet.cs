using VetClinic.Wpf.Core;
using VetClinic.Wpf.Model.Enums;

namespace VetClinic.Wpf.Model
{
    public abstract class Pet : BaseNotifyPropertyChanged
    {
        public Pet()
        {
            Id = string.Empty;
            Name = string.Empty;
            Breed = string.Empty;
            Age = null;
            Weight = null;
            Length = null;
            Height = null;
            Type = null;

            Owner = new Person();
        }

        public Pet(Pet pet)
        {
            Id = pet.Id;
            Name = pet.Name;
            Breed = pet.Breed;
            Age = pet.Age;
            Weight = pet.Weight;
            Length = pet.Length;
            Height = pet.Height;
            Type = pet.Type;

            Owner = pet.Owner;
        }

        private string _id;
        public string Id
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _breed;
        public string Breed
        {
            get { return _breed; }
            set
            {
                _breed = value;
                OnPropertyChanged(nameof(Breed));
            }
        }

        private int? _age;
        public int? Age
        {
            get { return _age; }
            set
            {
                _age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        private decimal? _weight;
        public decimal? Weight
        {
            get { return _weight; }
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        private decimal? _length;
        public decimal? Length
        {
            get { return _length; }
            set
            {
                _length = value;
                OnPropertyChanged(nameof(Length));
            }
        }

        private decimal? _height;
        public decimal? Height
        {
            get { return _height; }
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        private PetType? _type;
        public PetType? Type
        {
            get { return _type; }
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }

        private Person _owner;
        public Person Owner
        {
            get { return _owner; }
            set
            {
                _owner = value;
                OnPropertyChanged(nameof(Owner));
            }
        }

        #region Derived Properties

        public string NameAndOwner
        {
            get { return $"{Name}, owner: {Owner?.Name}"; }
        }

        #endregion Derived Properties


        // Return the cost of the treatment
        public abstract decimal GetTreatmentCost();


    }
}
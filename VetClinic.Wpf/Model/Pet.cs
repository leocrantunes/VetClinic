using VetClinic.Wpf.Core;
using VetClinic.Wpf.Model.Enum;

namespace VetClinic.Wpf.Model
{
    public class Pet : BaseNotifyPropertyChanged
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
            Gender = null;

            Owner = new Person();
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

        private Gender? _gender;
        public Gender? Gender
        {
            get { return _gender; }
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
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

        public string NameAndOwner
        {
            get { return $"{Name}, owner: {Owner?.Name}"; }
        }
    }
}
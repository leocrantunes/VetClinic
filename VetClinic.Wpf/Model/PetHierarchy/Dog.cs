using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Wpf.Model.PetHierarchy
{
    class Dog : Pet
    {
        public Dog(Pet pet) : base(pet)
        {
        }

        //Return basic tests cost
        public override decimal GetTreatmentCost()
        {
            switch (Weight)
            {
                case decimal value when (value < 2):
                    return 50;

                case decimal value when (value > 2 && value < 5):
                    return 100;

                default:
                    return 150;
            }
        }
    }
}





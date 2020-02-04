using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Wpf.Model
{
    class Cat : Pet
    {
        public Cat(Pet pet) : base(pet)
        {
        }

        //Return basic tests cost
        public override decimal GetTreatmentCost()
        {
            switch (Weight)
            {
                case decimal value when (value < 1):
                    return 20;

                case decimal value when (value > 1 && value < 2):
                    return 40;

                default:
                    return 60;
            }
        }
    }
}

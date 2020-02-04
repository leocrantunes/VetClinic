using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Wpf.Model.PetHierarchy
{
    class PetSurgery : ServiceDecorator
    {
        public PetSurgery(Pet pet) : base(pet)
        {
        }

        public override decimal GetTreatmentCost()
        {
            return _pet.GetTreatmentCost() + 60;
        }
    }
}

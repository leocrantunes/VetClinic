using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Wpf.Model.PetHierarchy
{
    class PetTherapy : ServiceDecorator
    {
        public override decimal GetTreatmentCost()
        {
            return _pet.GetTreatmentCost() + 40;
        }
    }
}

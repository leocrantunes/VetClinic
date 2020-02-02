using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Wpf.Model.PetHierarchy
{

    abstract class ServiceDecorator : Pet
    {
        private protected Pet _pet;
    }
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VetClinic.Wpf.Model;
using VetClinic.Wpf.ViewModel;

namespace VetClinic.Test
{
    [TestFixture]
    public class MainWindowViewModelTest
    {
        MainWindowViewModel fixture;

        [SetUp]
        public void Init()
        {
            fixture = new MainWindowViewModel();
        }

        [Test]
        public void CreatePatientTest()
        {
            var patient = new Pet();
            patient.Name = "Flipper";
            patient.Owner.FirstName = "John";
            patient.Owner.LastName = "Smith";

            fixture.AddPatient(patient);

            Assert.IsNotEmpty(fixture.VetClinic.Patients);
            Assert.AreEqual(1, fixture.VetClinic.Patients.Count);
            Assert.AreEqual(patient.Name, fixture.VetClinic.Patients.FirstOrDefault()?.Name);
        }
    }
}

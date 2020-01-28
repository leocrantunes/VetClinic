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

        Pet patient;
        Appointment appointment;

        [SetUp]
        public void Init()
        {
            fixture = new MainWindowViewModel();

            patient = new Pet();
            patient.Name = "Flipper";
            patient.Owner.FirstName = "John";
            patient.Owner.LastName = "Smith";

            appointment = new Appointment();
            appointment.Id = "1";
            appointment.Place = Wpf.Model.Enums.AppointmentPlace.Clinic;


        }

        [TestFixtureSetUp]

        public void TestFixtureInit()
        {
            fixture.VetClinic.Patients.Clear();
        }

        [Test]
        public void CreatePatientTest()
        {
            fixture.AddPatient(patient);

            Assert.IsNotEmpty(fixture.VetClinic.Patients);
            Assert.AreEqual(1, fixture.VetClinic.Patients.Count);
            Assert.AreEqual(patient.Name, fixture.VetClinic.Patients.FirstOrDefault()?.Name);
        }
        [Test]
        public void EditPatientTest()
        {

            fixture.AddPatient(patient);
            patient.Age = 1;
            fixture.EditPatient(patient);
            Assert.AreEqual(patient.Age, fixture.VetClinic.Patients.FirstOrDefault()?.Age);
            
        }

        [Test]
        public void RemovePatientTest()
        {
            fixture.AddPatient(patient);
            fixture.RemovePatient(patient);
            Assert.IsEmpty(fixture.VetClinic.Patients);
        }

        [Test]
        public void CreateAppointmentTest()
        {
            fixture.AddAppointment(appointment);

            Assert.IsNotEmpty(fixture.VetClinic.Schedule.Appointments);
            Assert.AreEqual(1, fixture.VetClinic.Schedule.Appointments.Count);
            Assert.AreEqual(appointment.Place, fixture.VetClinic.Schedule.Appointments.FirstOrDefault()?.Place);
        }
        [Test]
        public void EditAppointmentTest()
        {
            fixture.AddAppointment(appointment);
            appointment.Place = Wpf.Model.Enums.AppointmentPlace.ClientHouse;
            fixture.EditAppointment(appointment);
            Assert.AreEqual(appointment.Place, fixture.VetClinic.Schedule.Appointments.FirstOrDefault()?.Place);

        }


    }
}

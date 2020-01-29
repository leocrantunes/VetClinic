using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
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
        private MainWindowViewModel fixture;

        private Pet patient;
        private Appointment appointment;

        private string sourceDir = "Files";
        private string backupDir = @"";
        private string fName = "VetClinic.xml";

        [OneTimeSetUp]
        public void Init()
        {
            File.Delete(Path.Combine(backupDir, fName));
            fixture = new MainWindowViewModel();

            patient = new Pet();
            patient.Name = "Flipper";
            patient.Owner.FirstName = "John";
            patient.Owner.LastName = "Smith";

            appointment = new Appointment();
            appointment.Place = Wpf.Model.Enums.AppointmentPlace.Clinic;
        }

        [SetUp]
        public void TestFixtureInit()
        {
            fixture.VetClinic.Patients.Clear();
            fixture.VetClinic.Schedule.Appointments.Clear();
            fixture.ClearAllData();
            File.Delete(Path.Combine(backupDir, fName));
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

        [Test]
        public void RemoveAppointmentTest()
        {
            fixture.AddAppointment(appointment);
            fixture.RemoveAppointment(appointment);

            Assert.IsEmpty(fixture.VetClinic.Schedule.Appointments);
        }

        [Test]
        public void NameFliterTest()
        {
            fixture.AddPatient(patient);

            fixture.Filters.Name = "Flipper";
            fixture.Filters.IsNameSelected = true;

            fixture.FilterAppointments();

            Assert.IsTrue(appointment.IsVisible);
        }


        [Test]
        public void SaveXmlDataTest()
        {
            fixture.AddPatient(patient);
            fixture.AddAppointment(appointment);

            fixture.SaveXmlData();
            fixture.ClearAllData();
            fixture.ReadXmlData();

            Assert.AreEqual(1, fixture.VetClinic.Patients.Count);
            Assert.AreEqual(1, fixture.VetClinic.Schedule.Appointments.Count);
        }

        [Test]
        public void ReadXmlDataTest()
        {
            File.Copy(Path.Combine(sourceDir, fName), Path.Combine(backupDir, fName), true);

            fixture.ReadXmlData();

            Assert.AreEqual(3, fixture.VetClinic.Patients.Count);
            Assert.AreEqual(4, fixture.VetClinic.Schedule.Appointments.Count);

            Assert.AreEqual("a4f594684a8d442b951de8379719ba67", fixture.VetClinic.Patients.FirstOrDefault()?.Id);
            Assert.AreEqual("891dc5b2580243ce9d16bd97aa7fd4a7", fixture.VetClinic.Schedule.Appointments.FirstOrDefault()?.Id);
        }

        [Test]
        public void ClearDataTest()
        {
            fixture.AddPatient(patient);
            fixture.AddAppointment(appointment);
            fixture.VetClinic.Clear();

            Assert.IsEmpty(fixture.VetClinic.Patients);
            Assert.IsEmpty(fixture.VetClinic.Schedule.Appointments);
        }

    }
}

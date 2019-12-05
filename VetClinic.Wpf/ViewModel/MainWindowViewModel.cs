using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows.Data;
using System.Xml.Serialization;
using VetClinic.Wpf.Core;
using VetClinic.Wpf.Model;
using VetClinic.Wpf.Model.Enums;
using VetClinic.Wpf.Model.Filters;

namespace VetClinic.Wpf.ViewModel
{
    public class MainWindowViewModel : BaseNotifyPropertyChanged
    {
        private readonly string _xmlFileName = "VetClinic.xml";

        public MainWindowViewModel()
        {
            VetClinic = new Clinic();
            Filters = new AppointmentFilters();

            // load previous data
            ReadXmlData();
        }

        private Clinic _vetClinic;
        public Clinic VetClinic
        {
            get { return _vetClinic; }
            set
            {
                _vetClinic = value;
                OnPropertyChanged(nameof(VetClinic));
            }
        }

        private AppointmentFilters _filters;
        public AppointmentFilters Filters
        {
            get { return _filters; }
            set
            {
                _filters = value;
                OnPropertyChanged(nameof(Filters));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private ICollectionView _appointmentsView;
        public ICollectionView AppointmentsView
        {
            get { return _appointmentsView; }
            set
            {
                _appointmentsView = value;
                OnPropertyChanged(nameof(AppointmentsView));
            }
        }

        /// <summary>
        /// Save data to xml file
        /// </summary>
        public void SaveXmlData()
        {
            var serializer = new XmlSerializer(typeof(Clinic));
            var writer = new StreamWriter(_xmlFileName);
            serializer.Serialize(writer, VetClinic);
            writer.Close();
        }

        /// <summary>
        /// Read data from xml file
        /// </summary>
        public void ReadXmlData()
        {
            if (!File.Exists(_xmlFileName))
                return;

            var serializer = new XmlSerializer(typeof(Clinic));
            var reader = new StreamReader(_xmlFileName);
            VetClinic = (Clinic)serializer.Deserialize(reader);
            reader.Close();

            // set all appointments to visible state
            SetAllAppointmentsToVisible();

            // set collection view source for filtering
            AppointmentsView = CollectionViewSource.GetDefaultView(VetClinic.Schedule.Appointments);
        }

        /// <summary>
        /// Clear all data from memory, calling clear for all the lists
        /// </summary>
        public void ClearAllData()
        {
            VetClinic?.Clear();
            Filters.Reset();
        }

        /// <summary>
        /// Add patient to VetClinic object
        /// </summary>
        /// <param name="patient"></param>
        public void AddPatient(Pet patient)
        {
            patient.Id = Guid.NewGuid().ToString("n");
            VetClinic.Patients.Add(patient);
        }

        public void EditPatient(Pet newPatient)
        {
            var patientToEdit = VetClinic.Patients.FirstOrDefault(p => p.Id == newPatient.Id);
            if (patientToEdit == null)
            {
                throw new Exception("Patient not found");
            }

            var index = VetClinic.Patients.IndexOf(patientToEdit);
            VetClinic.Patients[index] = newPatient;

            UpdateAssociatedAppointments(newPatient);
        }

        /// <summary>
        /// Remove patient
        /// </summary>
        /// <param name="patient"></param>
        public void RemovePatient(Pet patient)
        {
            var patientToRemove = VetClinic.Patients.FirstOrDefault(p => p.Id == patient.Id);
            if (patientToRemove == null)
            {
                throw new Exception("Patient not found");
            }
            
            VetClinic.Patients.Remove(patientToRemove);
            RemoveAssociatedAppointments(patientToRemove);
        }

        private void UpdateAssociatedAppointments(Pet patient)
        {
            var appointments = from a in VetClinic.Schedule.Appointments.ToList()
                               where a.Patient?.Id == patient?.Id
                               select a;

            foreach (var appointment in appointments)
            {
                var index = VetClinic.Schedule.Appointments.IndexOf(appointment);
                VetClinic.Schedule.Appointments[index].Patient = patient;
            }
        }

        private void RemoveAssociatedAppointments(Pet patient)
        {
            var appointments = from a in VetClinic.Schedule.Appointments.ToList()
                               where a.Patient.Id == patient.Id
                               select a;

            foreach (var a in appointments)
            {
                RemoveAppointment(a);
            }
        }

        /// <summary>
        /// Add appointment to schedule
        /// </summary>
        /// <param name="appointment"></param>
        public void AddAppointment(Appointment appointment)
        {
            appointment.Id = Guid.NewGuid().ToString("n");
            VetClinic.Schedule.Appointments.Add(appointment);
        }

        /// <summary>
        /// Edit appointment in schedule
        /// </summary>
        /// <param name="oldAppointment"></param>
        /// <param name="newAppointment"></param>
        public void EditAppointment(Appointment newAppointment)
        {
            var appointmentToEdit = VetClinic.Schedule.Appointments.FirstOrDefault(a => a.Id == newAppointment.Id);
            if (appointmentToEdit == null)
            {
                throw new Exception("Appointment not found");
            }

            var index = VetClinic.Schedule.Appointments.IndexOf(appointmentToEdit);
            VetClinic.Schedule.Appointments[index] = newAppointment;
        }

        public void ResetFilters()
        {
            Filters.Reset();
        }

        /// <summary>
        /// Remove appointment
        /// </summary>
        /// <param name="appointment"></param>
        public void RemoveAppointment(Appointment appointment)
        {
            var appointmentToRemove = VetClinic.Schedule.Appointments.FirstOrDefault(a => a.Id == appointment.Id);
            if (appointmentToRemove == null)
            {
                throw new Exception("Appointment not found");
            }

            VetClinic.Schedule.Appointments.Remove(appointment);
        }
        
        /// <summary>
        /// Recommended way
        /// </summary>
        public void FilterAppointments()
        {
            AppointmentsView.Filter = 
                appointment => 
                    ContainsPatientName(((Appointment)appointment).Patient.Name) &&
                    AfterDateFrom(((Appointment)appointment).Date) &&
                    BeforeDateTo(((Appointment)appointment).Date) &&
                    EqualsPetType(((Appointment)appointment).Patient.Type) &&
                    EqualsServiceType(((Appointment)appointment).ServiceType);
        }

        /// <summary>
        /// Another way: using LINQ and IsVisibleProperty
        /// </summary>
        public void FilterAppointmentsV2()
        {
            var filtered = from appointment in VetClinic.Schedule.Appointments.ToList()
                           where ContainsPatientName(appointment.Patient.Name) &&
                                 AfterDateFrom(appointment.Date) &&
                                 BeforeDateTo(appointment.Date) &&
                                 EqualsPetType(appointment.Patient.Type) &&
                                 EqualsServiceType(appointment.ServiceType)
                           select appointment;

            foreach (var a in VetClinic.Schedule.Appointments)
            {
                a.IsVisible = filtered.Contains(a);
            }
        }

        private bool ContainsPatientName(string name)
        {
            return !Filters.IsNameSelected || Filters.IsNameSelected && name.ToLower().Contains(Filters.Name.ToLower());
        }

        private bool AfterDateFrom(DateTime date)
        {
            return !Filters.IsDateFromSelected || Filters.IsDateFromSelected && date >= Filters.DateFrom;
        }

        private bool BeforeDateTo(DateTime date)
        {
            return !Filters.IsDateToSelected || Filters.IsDateToSelected && date <= Filters.DateTo;
        }

        private bool EqualsPetType(PetType? type)
        {
            return !Filters.IsPetTypeSelected || Filters.IsPetTypeSelected && type == Filters.PetType;
        }

        private bool EqualsServiceType(ServiceType? type)
        {
            return !Filters.IsServiceTypeSelected || Filters.IsServiceTypeSelected && type == Filters.ServiceType;
        }

        public void SetAllAppointmentsToVisible()
        {
            foreach (var appointment in VetClinic.Schedule.Appointments)
            {
                appointment.IsVisible = true;
            }
        }
    }
}
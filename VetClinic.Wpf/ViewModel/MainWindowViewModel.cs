﻿using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using VetClinic.Wpf.Core;
using VetClinic.Wpf.Model;
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
        }

        /// <summary>
        /// Clear all data from memory, calling clear for all the lists
        /// </summary>
        public void ClearAllData()
        {
            VetClinic?.Clear();
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

        public void FilterAppointments()
        {
            var filtered = from appointment in VetClinic.Schedule.Appointments
                           where appointment.Patient.Name.ToLower().Contains(Filters.Name.ToLower())
                           select appointment;
        }
    }
}
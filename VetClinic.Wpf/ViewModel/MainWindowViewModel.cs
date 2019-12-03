using System;
using System.IO;
using System.Xml.Serialization;
using VetClinic.Wpf.Core;
using VetClinic.Wpf.Model;

namespace VetClinic.Wpf.ViewModel
{
    public class MainWindowViewModel : BaseNotifyPropertyChanged
    {
        private readonly string _xmlFileName = "VetClinic.xml";

        public MainWindowViewModel()
        {
            VetClinic = new Clinic();

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

        /// <summary>
        /// Add appointment to schedule
        /// </summary>
        /// <param name="appointment"></param>
        public void AddAppointment(Appointment appointment)
        {
            VetClinic.Schedule.Appointments.Add(appointment);
        }

        /// <summary>
        /// Edit appointment in schedule
        /// </summary>
        /// <param name="oldAppointment"></param>
        /// <param name="newAppointment"></param>
        public void EditAppointment(Appointment oldAppointment, Appointment newAppointment)
        {
            var index = VetClinic.Schedule.Appointments.IndexOf(oldAppointment);
            VetClinic.Schedule.Appointments[index] = newAppointment;
        }

        /// <summary>
        /// Remove appointment
        /// </summary>
        /// <param name="appointment"></param>
        public void RemoveAppointment(Appointment appointment)
        {
            // review algorithm
            VetClinic.Schedule.Appointments.Remove(appointment);
        }
    }
}
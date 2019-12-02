using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VetClinic.Wpf.Model
{
    public class Schedule
    {
        private const int SlotTimeBeginning = 9;
        private const int SlotLength = 8;
        private const int SlotSize = 1;
        
        private readonly Dictionary<int, DateTime> _slotToTime;

        public Schedule()
        {
            Appointments = new List<Appointment>(SlotLength);
            _slotToTime = InitializeSlotToTimeDictionary();
        }

        public List<Appointment> Appointments { get; set; }
        
        private Dictionary<int, DateTime> InitializeSlotToTimeDictionary()
        {
            var dictionary = new Dictionary<int, DateTime>();
            for (int i = 0; i < SlotLength; i++)
            {
                dictionary.Add(i, default(DateTime).Add(TimeSpan.FromHours(SlotTimeBeginning + i * SlotSize)));
            }

            return dictionary;
        }
        
        public void RegisterVehicle(int timeSlot, Appointment appointment)
        {
            if (timeSlot < 0 && timeSlot >= SlotLength)
            {
                Console.WriteLine($"'{timeSlot}' is an invalid slot. Time slot must be between 0 and {SlotLength - 1}.");
                return;
            }

            if (Appointments[timeSlot] != null)
            {
                Console.WriteLine($"There is already a vehicle registered for this time slot: {timeSlot}.");
                return;
            }

            Appointments[timeSlot] = new Appointment();
        }
    }
}
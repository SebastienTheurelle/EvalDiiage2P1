using System;
using EvaluationMauiDiiage.Models.Entities.Interfaces;

namespace EvaluationMauiDiiage.Models.Entities
{
    public class Appointment : IAppointment
    { 
        public long Id { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime ScheduledDate { get; set; }
        public bool IsActive { get; set; }

        public Appointment()
        {

        }

        public Appointment(string name, string note, DateTime scheduledDate) : this()
        {
            Name = name;
            Note = note;
            CreationDate = DateTime.Now;
            ScheduledDate = scheduledDate;
            IsActive = true;
        }

        public Appointment(IAppointment appointment) : this()
        {
            Id = appointment.Id;
            Name = appointment.Name;
            Note = appointment.Note;
            CreationDate = appointment.CreationDate;
            ScheduledDate = appointment.ScheduledDate;
            IsActive = appointment.IsActive;
        }
    }
}


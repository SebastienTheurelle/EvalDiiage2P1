using System;
using EvaluationMauiDiiage.Models.Dtos.Down;
using Newtonsoft.Json;

namespace EvaluationMauiDiiage.Models.Wrapper
{
    public class AppointmentWrapper
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("scheduledDate")]
        public DateTime ScheduledDate { get; set; }

        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        public AppointmentWrapper(AppointmentDownDto appointment)
        {
            Id = appointment.Id;
            Name = appointment.Name;
            Note = appointment.Note;
            CreationDate = appointment.CreationDate;
            ScheduledDate = appointment.ScheduledDate;
            IsActive = appointment.IsActive;
            Label = $"{appointment.Name} at {appointment.ScheduledDate}";
        }
    }
}


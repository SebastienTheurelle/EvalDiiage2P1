using System;
using EvaluationMauiDiiage.Models.DTO.Down;

namespace EvaluationMauiDiiage.Models.Wrappers
{
    public class MeetingsWrapper
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Note { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime ScheduledDate { get; set; }

        public MeetingsWrapper(MeetingsDTODown meetingsDTODown)
        {
            Id = meetingsDTODown.Id;
            Name = meetingsDTODown.Name;
            Note = meetingsDTODown.Note;
            CreationDate = meetingsDTODown.CreationDate;
            ScheduledDate = meetingsDTODown.ScheduledDate;
        }
    }
}


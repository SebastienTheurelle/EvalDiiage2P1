using System;
namespace EvaluationMauiDiiage.Models.Entities.Interfaces
{
    public interface IAppointment
    {
        long Id { get; set; }
        string Name { get; set; }
        string Note { get; set; }
        DateTime CreationDate { get; set; }
        DateTime ScheduledDate { get; set; }
        bool IsActive { get; set; }
    }
}


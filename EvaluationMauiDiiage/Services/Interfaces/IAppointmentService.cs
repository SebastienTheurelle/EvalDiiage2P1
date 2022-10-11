using System;
using EvaluationMauiDiiage.Models.Wrapper;

namespace EvaluationMauiDiiage.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<IEnumerable<AppointmentWrapper>> GetAll();

        //AppointmentWrapper GetById();
    }
}


using System;
using System.Collections.ObjectModel;
using EvaluationMauiDiiage.Helper.Interfaces;
using EvaluationMauiDiiage.Models.Dtos.Down;
using EvaluationMauiDiiage.Models.Wrapper;
using EvaluationMauiDiiage.Services.Interfaces;

namespace EvaluationMauiDiiage.Services
{
    public class AppointmentService : IAppointmentService
    {
        #region Attributes Privates
        private ISerializationHelper _serializationHelper;
        private IServiceSource _serviceSource;
        #endregion

        #region CTOR
        public AppointmentService(ISerializationHelper serializationHelper, IServiceSource serviceSource)
        {
            _serializationHelper = serializationHelper;
            _serviceSource = serviceSource;
        }
        #endregion

        #region Method
        public async Task<IEnumerable<AppointmentWrapper>> GetAll()
        {
            var json = await _serviceSource.GetSourceFileContent();
            var appointments = _serializationHelper.Deserialize<IEnumerable<AppointmentDownDto>>(json);

            return appointments.Select(dto => new AppointmentWrapper(dto));
        }

        //public AppointmentWrapper GetById()
        //{

        //}
        #endregion
    }
}


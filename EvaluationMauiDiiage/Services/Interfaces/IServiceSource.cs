using EvaluationMauiDiiage.Models.Entity;

namespace EvaluationMauiDiiage.Services.Interfaces
{
    public interface IServiceSource
    {
        Task<List<RdvEntity>> GetSourceFileContent();

        Task<RdvEntity> GetById(long id);
    }
}

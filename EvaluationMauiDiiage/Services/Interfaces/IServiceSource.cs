using EvaluationMauiDiiage.Models.Dtos.Down;

namespace EvaluationMauiDiiage.Services.Interfaces
{
    public interface IServiceSource
    {
        Task<string> GetSourceFileContent();

        Task<List<RendezVousDtoDown>> GetRendezVousAsync();
    }
}

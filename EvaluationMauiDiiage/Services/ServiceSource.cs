using EvaluationMauiDiiage.Models.Dtos.Down;
using EvaluationMauiDiiage.Services.Interfaces;
using Newtonsoft.Json;

namespace EvaluationMauiDiiage.Services
{
    public class ServiceSource : IServiceSource
    {
        public async Task<string> GetSourceFileContent()
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("source.json");
                using var reader = new StreamReader(stream);

                var content = await reader.ReadToEndAsync();

                return content;
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        public async Task<List<RendezVousDtoDown>> GetRendezVousAsync()
        {
            var source = await this.GetSourceFileContent();

            var data = JsonConvert.DeserializeObject<List<RendezVousDtoDown>>(source).OrderBy(rdv => rdv.ScheduledDate).ToList();

            return data;
        }
    }
}
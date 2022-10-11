using System;
using EvaluationMauiDiiage.Services.Interfaces;

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
    }
}

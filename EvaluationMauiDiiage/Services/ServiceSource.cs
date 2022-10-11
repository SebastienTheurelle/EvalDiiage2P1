using EvaluationMauiDiiage.Models;
using EvaluationMauiDiiage.Services.Interfaces;
using System;
using System.Text.Json;

namespace EvaluationMauiDiiage.Services
{
    public class ServiceSource : IServiceSource
    {
        List<RDVEntity> rdvList = new();

        public async Task<List<RDVEntity>> GetSourceFileContent()
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("source.json");
                using var reader = new StreamReader(stream);
                var content = await reader.ReadToEndAsync();
                rdvList = JsonSerializer.Deserialize<List<RDVEntity>>(content);


                return rdvList;
            }
            catch (Exception ex)
            {
                return new List<RDVEntity>();
            }
        }
        HttpClient httpClient;
        public ServiceSource()
        {
            this.httpClient = new HttpClient();
        }
    }
}
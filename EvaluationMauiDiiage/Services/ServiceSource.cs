using EvaluationMauiDiiage.Models.Entity;
using EvaluationMauiDiiage.Services.Interfaces;
using Newtonsoft.Json;
using System;

namespace EvaluationMauiDiiage.Services
{
    public class ServiceSource : IServiceSource
    {
        public async Task<RdvEntity> GetById(long id)
        {
            RdvEntity Rdv = new RdvEntity();
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("source.json");
                using var reader = new StreamReader(stream);

                var content = await reader.ReadToEndAsync();

                Rdv = JsonConvert.DeserializeObject<List<RdvEntity>>(content).FirstOrDefault(r => r.Id == id);

                return Rdv;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return Rdv;
            }
        }

        public async Task<List<RdvEntity>> GetSourceFileContent()
        {
            List<RdvEntity> LstRdv = new List<RdvEntity>();
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("source.json");
                using var reader = new StreamReader(stream);

                var content = await reader.ReadToEndAsync();
                
                LstRdv = JsonConvert.DeserializeObject<List<RdvEntity>>(content).OrderBy(r => r.CreationDate).ToList();

                return LstRdv;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return LstRdv;
            }
        }
    }
}
using System;
using System.Collections.Generic;
using EvaluationMauiDiiage.Models;
using EvaluationMauiDiiage.Models.DTO.Down;
using EvaluationMauiDiiage.Models.Wrappers;
using EvaluationMauiDiiage.Services.Interfaces;
using Newtonsoft.Json;

namespace EvaluationMauiDiiage.Services
{
    public class MeetingsService : IMeetingsService
    {
        public async Task<string> GetSourceFileContent()
        {
            try
            {
                using var stream = await FileSystem.OpenAppPackageFileAsync("source.json");
                using var reader = new StreamReader(stream);

                var content = await reader.ReadToEndAsync();

                // I don't know how to convert our Json File to an IEnumerable of MeetingsDTODown
                //MeetingEntity meetings = JsonSerializer.Deserialize<MeetingEntity>(content);
                return content;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
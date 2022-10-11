using System;
using EvaluationMauiDiiage.Models.DTOs;
using EvaluationMauiDiiage.Models.Interfaces;
using EvaluationMauiDiiage.Services.Interfaces;
using Newtonsoft.Json;

namespace EvaluationMauiDiiage.Services;

public class ResourceService : IResourceService
{
	public ResourceService()
	{
	}

    public async Task<IResourceEntity> GetResourceAsync(long id)
    {
        var resources = await GetResourcesAsync();
        return resources?.FirstOrDefault(r => r.Id == id);
    }

    public async Task<IEnumerable<IResourceEntity>> GetResourcesAsync()
    {
        try
        {
            using var stream = await FileSystem.OpenAppPackageFileAsync("source.json");
            using var reader = new StreamReader(stream);

            var content = await reader.ReadToEndAsync();
            var dtos = JsonConvert.DeserializeObject<IEnumerable<ResourceDTODown>>(content);

            return dtos;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            return null;
        }
    }
}


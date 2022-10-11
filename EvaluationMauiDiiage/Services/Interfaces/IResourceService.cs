using System;
using EvaluationMauiDiiage.Models.Interfaces;

namespace EvaluationMauiDiiage.Services.Interfaces;

public interface IResourceService
{
    Task<IEnumerable<IResourceEntity>> GetResourcesAsync();
    Task<IResourceEntity> GetResourceAsync(long id);
}


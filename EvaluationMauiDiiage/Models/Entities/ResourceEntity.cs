using System;
using EvaluationMauiDiiage.Models.Interfaces;
using Newtonsoft.Json;

namespace EvaluationMauiDiiage.Models.Entities;

public class ResourceEntity : IResourceEntity
{
	public ResourceEntity()
	{
	}

    public ResourceEntity(IResourceEntity resource)
    {
        Id = resource.Id;
        Name = resource.Name;
        Note = resource.Note;
        CreationDate = resource.CreationDate;
        ScheduledDate = resource.ScheduledDate;
        IsActive = resource.IsActive;
    }

    public long Id { get; set; }

    public string Name { get; set; }

    public string Note { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ScheduledDate { get; set; }

    public bool IsActive { get; set; }

}


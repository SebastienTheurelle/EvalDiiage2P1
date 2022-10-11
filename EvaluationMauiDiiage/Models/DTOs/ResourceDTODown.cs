using System;
using EvaluationMauiDiiage.Models.Interfaces;
using Newtonsoft.Json;

namespace EvaluationMauiDiiage.Models.DTOs;

public class ResourceDTODown : IResourceEntity
{
	public ResourceDTODown()
	{
	}

    [JsonProperty("id")]
    public long Id { get; set; }

    [JsonProperty("name")]
    public string Name { get; set; }

    [JsonProperty("note")]
    public string Note { get; set; }

    [JsonProperty("creationDate")]
    public DateTime CreationDate { get; set; }

    [JsonProperty("scheduledDate")]
    public DateTime ScheduledDate { get; set; }

    [JsonProperty("isActive")]
    public bool IsActive { get; set; }
}


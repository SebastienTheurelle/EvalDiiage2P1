using System;
using Newtonsoft.Json;

namespace EvaluationMauiDiiage.Models.DTO.Down
{
    public class MeetingsDTODown
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("note")]
        public string Note { get; set; }

        [JsonProperty("creationDate")]
        public DateTime CreationDate { get; set; }

        [JsonProperty("scheduledDate")]
        public DateTime ScheduledDate { get; set; }

        public MeetingsDTODown()
        {
        }
    }
}


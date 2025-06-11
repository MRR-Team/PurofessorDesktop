using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Purofessor.Models
{
    using System.Text.Json.Serialization;

    public class ActivityLog
    {
        public int Id { get; set; }

        [JsonPropertyName("log_name")]
        public string? LogName { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("subject_type")]
        public string? SubjectType { get; set; }

        [JsonPropertyName("subject_id")]
        public int? SubjectId { get; set; }

        [JsonPropertyName("causer_type")]
        public string? CauserType { get; set; }

        [JsonPropertyName("causer_id")]
        public int? CauserId { get; set; }

        [JsonPropertyName("properties")]
        public JsonElement? Properties { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        public string CreatedAtDisplay => CreatedAt.ToString("yyyy-MM-dd HH:mm:ss");
        public string CauserIdDisplay => CauserId?.ToString() ?? "brak";
    }

}


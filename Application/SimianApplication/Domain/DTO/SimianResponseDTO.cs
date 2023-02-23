using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.DTO
{
    public class SimianResponseDTO
    {
        [JsonPropertyName("is_simian")]
        public bool IsSimian { get; set; }
    }
}

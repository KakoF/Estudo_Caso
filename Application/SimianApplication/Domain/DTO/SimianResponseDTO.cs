using System;
using System.Text.Json.Serialization;

namespace Domain.DTO
{
    public class SimianResponseDTO
    {
        [JsonPropertyName("is_simian")]
        public bool IsSimian { get; set; }

        public SimianResponseDTO(bool isSimimian)
        {
            IsSimian= isSimimian;
        }

    }
}

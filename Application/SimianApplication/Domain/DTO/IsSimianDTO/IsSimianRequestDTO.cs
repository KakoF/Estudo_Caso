using Domain.DTO.IsSimianDTO.Validators;

namespace Domain.DTO.IsSimianDTO
{
    public class IsSimianRequestDTO : BaseRequestDTO
    {
        public string[] Dna { get; set; }

        public IsSimianRequestDTO(string[] dna)
        {
            Dna = dna;
            Validate(this, new IsSimianValidator());
        }
    }
}

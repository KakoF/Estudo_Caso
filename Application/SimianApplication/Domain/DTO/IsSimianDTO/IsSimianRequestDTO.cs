using Domain.DTO.IsSimianDTO.Validators;

namespace Domain.DTO.IsSimianDTO
{
    public class IsSimianRequestDTO
    {
        public string[] Dna { get; set; }

        /*public IsSimianRequestDTO(string[] dna)
        {
            Dna = dna;
            _ = ValidateAsync(this, new IsSimianValidator());
        }*/
    }
}

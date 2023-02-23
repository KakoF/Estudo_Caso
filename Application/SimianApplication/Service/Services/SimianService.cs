using Domain.DTO;
using Domain.Interfaces.Services;
using Domain.Abstractions;

namespace Service.Services
{
    public class SimianService : ISimianService
    {
        private readonly ISimianPatternsExecute _patternsExecute;
       
        public SimianService(ISimianPatternsExecute patternsExecute)
        {
            _patternsExecute = patternsExecute;
        }
        public SimianResponseDTO VerifyDna(SimianRequestDTO data)
        {
            var result = _patternsExecute.Execute(data.Dna);
            return new SimianResponseDTO(result.Where(x => x.Equals(true)).Count() >= 2);
        } 
        
    }
}

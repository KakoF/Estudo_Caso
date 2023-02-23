using Domain.DTO;
using Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SimianDnaVerifyService : ISimianDnaVerifyService
    {
        private readonly ISimianPattern _simianPattern;
        public SimianDnaVerifyService(ISimianPattern simianPattern)
        {
            _simianPattern= simianPattern;
        }
        public SimianResponseDTO Verify(SimianRequestDTO data)
        {
            _simianPattern.CheckPattern(data.Dna);
            return new SimianResponseDTO();
        }
    }
}

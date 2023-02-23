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
        public SimianResponseDTO Verify(SimianRequestDTO data)
        {
            return new SimianResponseDTO();
        }
    }
}

using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface ISimianRepository
    {
        Task<SimianEntity> Create(SimianEntity data);

        Task<IEnumerable<SimianEntity>> Get();
    }
}

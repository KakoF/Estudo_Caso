using Domain.Models.Clients.Advice;
using Domain.Models.Clients.ChuckNorris;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IChuckNorrisService
    {
        Task<ChuckNorrisModel> Get();
    }
}

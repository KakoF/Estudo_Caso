using Domain.Interfaces.Services;
using Domain.Models.Clients;
using Domain.Models.Clients.Advice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Clients
{
    public interface IAdviceClient: IClientFactory<AdviceModel, ClientResponseModel>
    {
    }
}

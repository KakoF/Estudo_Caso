using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Interfaces
{
    public interface IDbConnector
    {
        IDbConnection dbConnection { get; }
        IDbTransaction dbTransaction { get; set; }
    }
}

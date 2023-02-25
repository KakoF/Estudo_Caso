using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Interfaces;
using Dapper;

namespace Infra.Repositories
{
    public class SimianCalcRepository : ISimianCalcRepository
    {
        private readonly IDbConnector _connector;
        public SimianCalcRepository(IDbConnector connector)
        {
            _connector = connector;
        }

        public async Task<ViewSimianCalcEntity> GetAsync()
        {
            return await _connector.dbConnection.QueryFirstOrDefaultAsync<ViewSimianCalcEntity>("select total, count_is_simian as CountIsSimian, count_is_human as CountIsHuman, is_simian_percent as IsSimianPercent, is_human_percent as IsHumanPercent, ratio from view_calc_simian");
        }
    }
}

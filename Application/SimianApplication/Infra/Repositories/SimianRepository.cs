using Domain.Entities;
using Domain.Interfaces.Repositories;
using Infra.Interfaces;
using Dapper;

namespace Infra.Repositories
{
    public class SimianRepository : ISimianRepository
    {
        private readonly IDbConnector _connector;
        public SimianRepository(IDbConnector connector)
        {
            _connector = connector;
        }
        public async Task<SimianEntity> Create(SimianEntity data)
        {
            using (var conn = _connector.dbConnection)
            {
                var entity = await conn.QuerySingleAsync<SimianEntity>("INSERT INTO Simian(dna, is_simian) VALUES (@dna, @isSimian) RETURNING  id, dna, is_simian as IsSimian, created_at as CreatedAt, updated_at as UpdatedAt ;", new { dna = data.Dna, isSimian = data.IsSimian });
                return entity;
            }
        }

        public async Task<IEnumerable<SimianEntity>> Get()
        {
            using (var conn = _connector.dbConnection)
            {
                return await conn.QueryAsync<SimianEntity>("Select id, dna, is_simian as IsSimian, created_at as CreatedAt, updated_at as UpdatedAt from Simian");
            }
           
        }
    }
}

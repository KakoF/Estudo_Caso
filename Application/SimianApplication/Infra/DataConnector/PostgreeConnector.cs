﻿using Infra.Interfaces;
using Npgsql;
using System.Data;

namespace Infra.DataConnector
{
    public class PostgreeConnector : IDbConnector
    {
        public PostgreeConnector(string connectionString)
        {
            dbConnection = new NpgsqlConnection(connectionString);
            //dbConnection.ConnectionString = connectionString;
        }

        public IDbConnection dbConnection { get; }

        public IDbTransaction dbTransaction { get; set; }

        public IDbTransaction BeginTransaction(IsolationLevel isolation)
        {
            if (dbTransaction != null)
            {
                return dbTransaction;
            }

            if (dbConnection.State == ConnectionState.Closed)
            {
                dbConnection.Open();
            }

            return (dbTransaction = dbConnection.BeginTransaction(isolation));
        }

        public void Dispose()
        {
            dbConnection?.Dispose();
        }
    }
}
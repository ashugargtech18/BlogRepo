using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Infrastructure.Data
{
    public class ConnectionDataService : IConnectionDataService
    {
        private IDbConnection _connection;

        private const string ConnectionString  = "Server=.;Database=Blog;Trusted_Connection=True;MultipleActiveResultSets=true";

        
        public ConnectionDataService()
        {
            
        }
        /// <summary>
        /// Get Database Connection 
        /// </summary>
        public IDbConnection GetConnection
        {
            get {
                if (_connection == null)
                    _connection = new SqlConnection(ConnectionString);

                return _connection;
            }
        }
    }
}

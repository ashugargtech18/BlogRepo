using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Domain.Interfaces
{
    public interface IConnectionDataService
    {
        IDbConnection GetConnection { get; }
    }
}

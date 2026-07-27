using ix.Domain.Abstractions;
using ix.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ix.DataSource.Repositories;

public class PostgresRepository : IRepository
{
    public Task<bool> AddAsync(string fileName, IEnumerable<TimeScale> timeScalse)
    {
        throw new NotImplementedException();
    }
}

using ix.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ix.Domain.Abstractions;

public interface IRepository
{
    Task<bool> AddAsync(string fileName, IEnumerable<TimeScale> timeScalse);
}

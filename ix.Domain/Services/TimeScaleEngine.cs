using ix.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ix.Domain.Services;

public class TimeScaleEngine(
    IRepository _repository
    ) : ITimeScaleEngine
{
    public async Task SaveCSVAsync(string fileName, IEnumerable<string> lines)
    {
        throw new NotImplementedException();
    }
}

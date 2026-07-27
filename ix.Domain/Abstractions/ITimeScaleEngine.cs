using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ix.Domain.Abstractions;

public interface ITimeScaleEngine
{
    Task SaveCSVAsync(string fileName, IEnumerable<string> lines);
}

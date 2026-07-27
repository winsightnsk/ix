using ix.Domain.Abstractions;
using ix.Domain.Models;
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
        if (string.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentException("Пустое имя файла");
        }


    }

    private static TimeScale? ParseTimeScale
}

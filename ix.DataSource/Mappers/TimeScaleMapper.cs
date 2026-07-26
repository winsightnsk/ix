using ix.DataSource.Abstractions;
using ix.DataSource.Models;
using ix.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ix.DataSource.Mappers;

public class TimeScaleMapper : ITimeScaleMapper
{
    public TimeScaleEntity ToDataSource(TimeScale domain) => new(
        startedAt: domain.StartedAt,
        duration: domain.Duration,
        value: domain.Value
        );


    public TimeScale ToDomain(TimeScaleEntity entity) => new(
        startedAt: entity.StartedAt,
        duration: entity.Duration,
        value: entity.Value
        );
}

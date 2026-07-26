using ix.DataSource.Models;
using ix.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ix.DataSource.Abstractions;

public interface ITimeScaleMapper
{
    TimeScale ToDomain(TimeScaleEntity entity);
    TimeScaleEntity ToDataSource(TimeScale domain);
}

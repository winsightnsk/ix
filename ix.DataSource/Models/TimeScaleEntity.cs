using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ix.DataSource.Models;

public class TimeScaleEntity(DateTime startedAt, int duration, double value)
{
    public int Id { get; set; }
    public int FileId { get; set; }
    public DateTime StartedAt { get; set; } = startedAt;
    public int Duration { get; set; } = duration;
    public double Value { get; set; } = value;

    public TimeScaleEntity() : this(DateTime.UtcNow, 0, 0) { }

}

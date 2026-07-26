using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ix.Domain.Models;

public class TimeScale(DateTime startedAt, int duration, double value)
{
    public DateTime StartedAt { get; set; } = startedAt;
    public int Duration { get; set; } = duration;
    public double Value { get; set; } = value;

    //public override bool Equals(object? obj) =>
    //    obj is TimeScale other
    //    && this.Id.Equals(other.Id);

    //public static bool operator ==(TimeScale left, TimeScale right) =>
    //    left.Equals(right);
    //public static bool operator !=(TimeScale left, TimeScale right) => 
    //    !left.Equals(right);

    //public override int GetHashCode() => Id.GetHashCode();
}

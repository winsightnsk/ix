using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ix.Domain.Models;

public partial class TimeScale(DateTime startedAt, int duration, double value)
{
    public DateTime StartedAt { get; set; } = startedAt;
    public int Duration { get; set; } = duration;
    public double Value { get; set; } = value;

    public static bool TryParse(string txt, out TimeScale timeScale)
    {
        timeScale = new (DateTime.UtcNow, 0, 0);
        
        Regex _timeScaleRegex = CSVRegex();

        var match = _timeScaleRegex.Match(txt);
        if (!match.Success) return false;

        var startedAtStr = match.Groups["startedAt"].Value;

        return true;
    }

    [GeneratedRegex(@"""
        ^\s*(?<startedAt>\d{4}-\d{2}-\d{2}T\d{2}-\d{2}-\d{2}\.\d{4}Z)\s*;
        \s*(?<duration>\d+)\s*;
        \s*(?<value>-?\d+(?:\.\d+)?)
        """, 
        RegexOptions.Compiled | RegexOptions.CultureInvariant)
        ]
    private static partial Regex CSVRegex(); 
}

    //public override bool Equals(object? obj) =>
    //    obj is TimeScale other
    //    && this.Id.Equals(other.Id);

    //public static bool operator ==(TimeScale left, TimeScale right) =>
    //    left.Equals(right);
    //public static bool operator !=(TimeScale left, TimeScale right) => 
    //    !left.Equals(right);

    //public override int GetHashCode() => Id.GetHashCode();
//}

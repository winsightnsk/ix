using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ix.DataSource.Models;

public class FileEntity(string fileName)
{
    public int Id { get; set; }
    public string FileName { get; set; } = fileName;
    public DateTime SavedAt { get; set; } = DateTime.UtcNow;

    public ICollection<TimeScaleEntity> Values { get; set; } = [];
}

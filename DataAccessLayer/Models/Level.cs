using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Level
    {
        public Guid? LevelId { get; set; }
        public string? Value { get; set; }
        public ICollection<Task>? Task { get; set; }
    }
}

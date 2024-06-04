using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Level
    {
        public int? LevelId { get; set; }
        public string? level { get; set; }
        public ICollection<Task>? Tasks { get; set; }
    }
}

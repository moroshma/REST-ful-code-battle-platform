using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Task
    {
        public int? TaskId { get; set; }
        public string? TestCaseId { get; set; }
        public string? SolutionId { get; set; }
        public int? LevelId { get; set; }

        public TestCase? TestCase { get; set; }
        public Solution? Solution { get; set; }
        public Level? Level { get; set; }
    }
}

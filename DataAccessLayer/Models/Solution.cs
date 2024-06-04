using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Solution
    {
        public Guid? SolutionId { get; set; }
        public string? CaseSolution { get; set; }
        public Guid? TaskId { get; set; }
        public Task? Task { get; set; }
    }
}

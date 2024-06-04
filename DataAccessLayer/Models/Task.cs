﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Models
{
    public class Task
    {
        public Guid? TaskId { get; set; }
        public Guid? SolutionId { get; set; }
        public Guid? LevelId { get; set; }

        public ICollection<TestCase>? TestCase { get; set; }
        public ICollection<Solution>? Solution { get; set; }
        public Level? Level { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CrowdFunding.Models
{
    public partial class ReachGoal
    {
        public int ReachGoalId { get; set; }
        public int ProjectId { get; set; }
        public bool Flag { get; set; }
    }
}

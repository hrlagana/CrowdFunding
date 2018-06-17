using System;
using System.Collections.Generic;

namespace CrowdFunding.Models
{
    public partial class ProjectBacker
    {
        public int ProjectId { get; set; }
        public int BackerId { get; set; }

        public Backer Backer { get; set; }
        public Project Project { get; set; }
    }
}

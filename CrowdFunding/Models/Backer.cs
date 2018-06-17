using System;
using System.Collections.Generic;

namespace CrowdFunding.Models
{
    public partial class Backer
    {
        public Backer()
        {
            ProjectBacker = new HashSet<ProjectBacker>();
        }

        public int BackerId { get; set; }
        public string UserId { get; set; }
        public decimal Fund { get; set; }

        public AspNetUsers User { get; set; }
        public ICollection<ProjectBacker> ProjectBacker { get; set; }
    }
}

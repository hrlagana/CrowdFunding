using System;
using System.Collections.Generic;

namespace CrowdFunding.Models
{
    public partial class ProjectCreator
    {
        public ProjectCreator()
        {
            Project = new HashSet<Project>();
        }

        public int ProjectCreatorId { get; set; }
        public string UserId { get; set; }

        public AspNetUsers User { get; set; }
        public ICollection<Project> Project { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace CrowdFunding.Models
{
    public partial class Photo
    {
        public int PhotoId { get; set; }
        public int ProjectId { get; set; }
        public string PhotoName { get; set; }
        public string PhotoPath { get; set; }

        public Project Project { get; set; }
    }
}

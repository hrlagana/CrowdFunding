using System;
using System.Collections.Generic;

namespace CrowdFunding.Models
{
    public partial class Video
    {
        public int VideoId { get; set; }
        public int ProjectId { get; set; }
        public string VideoName { get; set; }
        public string VideoPath { get; set; }

        public Project Project { get; set; }
    }
}

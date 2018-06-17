using System;
using System.Collections.Generic;

namespace CrowdFunding.Models
{
    public partial class Benefit
    {
        public int BenefitId { get; set; }
        public string BenefitName { get; set; }
        public string BenefitDesciption { get; set; }
        public int ProjectId { get; set; }

        public Project Project { get; set; }
    }
}

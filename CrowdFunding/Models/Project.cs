using System;
using System.Collections.Generic;

namespace CrowdFunding.Models
{
    public partial class Project
    {
        public Project()
        {
            Benefit = new HashSet<Benefit>();
            Photo = new HashSet<Photo>();
            Progress = new HashSet<Progress>();
            ProjectBacker = new HashSet<ProjectBacker>();
            Video = new HashSet<Video>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public decimal AskedFund { get; set; }
        public int Days { get; set; }
        public int ProjectCreatorId { get; set; }
        public byte NumberOfBenefits { get; set; }
        public int CategoryId { get; set; }
        public int? BackersCount { get; set; }
        public string PhotoPath { get; set; }
        public string VideoPath { get; set; }
        public string VideoUrl { get; set; }

        public Category Category { get; set; }
        public ProjectCreator ProjectCreator { get; set; }
        public ICollection<Benefit> Benefit { get; set; }
        public ICollection<Photo> Photo { get; set; }
        public ICollection<Progress> Progress { get; set; }
        public ICollection<ProjectBacker> ProjectBacker { get; set; }
        public ICollection<Video> Video { get; set; }
    }
}

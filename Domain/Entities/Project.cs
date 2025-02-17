using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Project
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime? ProjectDate { get; set; }
        public string? Link { get; set; }
        public bool HasPublicLink { get; set; } = false;
        public List<ProjectTags>? Tags { get; set; } = new List<ProjectTags>();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class ProjectTags//Bridging table
    {
        public int ProjectID { get; set; }
        public Project Project { get; set; }
        public int TagID { get; set; }
        public Tag Tag { get; set; }
    }
}

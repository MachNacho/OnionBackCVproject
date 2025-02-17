using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Education
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? EducationLevel { get; set; }
        public string? Institution { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Description { get; set; }
        public string? ImageSrc { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Entities
{
    public class Seniority
    {
        public int Id { get; set; }
        public string SeniorityName { get; set; }
        public double Multiplier { get; set; }
        public int AssignmentOrder { get; set; }
        public TeamMember TeamMember { get; set; }
    }
}

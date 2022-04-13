using SupportManagement.Model.Model.Dto.TeamMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Model.Model.Dto.Seniority
{
    public class SeniorityDto
    {
        public int Id { get; set; }
        public string SeniorityName { get; set; }
        public double Multiplier { get; set; }
        public int AssignmentOrder { get; set; }
        public TeamMemberDto TeamMember { get; set; }
    }
}

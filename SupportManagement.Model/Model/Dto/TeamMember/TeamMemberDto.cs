using SupportManagement.Model.Model.Dto.Seniority;
using SupportManagement.Model.Model.Dto.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Model.Model.Dto.TeamMember
{
    public class TeamMemberDto
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int SeniorityId { get; set; }
        public SeniorityDto Seniority { get; set; }
        public TeamDto Team { get; set; }
    }
}

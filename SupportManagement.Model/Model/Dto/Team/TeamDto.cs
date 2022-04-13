using SupportManagement.Model.Model.Dto.TeamMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Model.Model.Dto.Team
{
    public class TeamDto
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public TimeSpan ShiftStarts { get; set; }
        public TimeSpan ShiftEnds { get; set; }
        public bool IsOverflowTeam { get; set; }

        public ICollection<TeamMemberDto> TeamMembers { get; set; }
    }
}

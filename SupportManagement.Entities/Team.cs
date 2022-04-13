using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string TeamName { get; set; }
        public TimeSpan ShiftStarts { get; set; }
        public TimeSpan ShiftEnds { get; set; }
        public bool IsOverflowTeam { get; set; }

        public ICollection<TeamMember> TeamMembers { get; set; }
    }
}

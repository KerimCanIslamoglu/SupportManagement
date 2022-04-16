using SupportManagement.Model.Model.Dto.TeamMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Model.Model.Dto.SupportQueue
{
    public class SupportQueueDto
    {
        public int Id { get; set; }
        public int TeamMemberId { get; set; }
        public TeamMemberDto TeamMember { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? AssignedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Entities
{
    public class SupportQueue
    {
        public int Id { get; set; }
        public int TeamMemberId { get; set; }
        public TeamMember TeamMember { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime? AssignedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

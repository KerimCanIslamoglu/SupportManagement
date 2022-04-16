using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Entities
{
    public class TeamMember
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int SeniorityId { get; set; }
        public Seniority Seniority { get; set; }
        public Team Team { get; set; }
        public string QueueName { get; set; }
        public ICollection<Chat> Chats { get; set; }
        public ICollection<SupportQueue> SupportQueues { get; set; }
    }
}

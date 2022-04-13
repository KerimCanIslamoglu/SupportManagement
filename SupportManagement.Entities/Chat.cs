using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int TeamMemberId { get; set; }
        public TeamMember TeamMember { get; set; }
        public DateTime SentOn { get; set; }
    }
}

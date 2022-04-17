using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Model.Model.Dto.Chat
{
    public class CreateChatDto
    {
        public string Content { get; set; }
        public int? UserId { get; set; }
        public int? TeamMemberId { get; set; }
        public bool IsSentByUser { get; set; }
    }
}

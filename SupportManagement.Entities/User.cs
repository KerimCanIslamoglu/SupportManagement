using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public ICollection<Chat> Chats { get; set; }
    }
}

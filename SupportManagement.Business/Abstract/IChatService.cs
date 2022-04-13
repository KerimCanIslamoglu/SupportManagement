using SupportManagement.Entities;
using SupportManagement.Model.Model;
using SupportManagement.Model.Model.Dto.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Business.Abstract
{
    public interface IChatService
    {
        ResponseModel<CreateChatDto> CreateChat(CreateChatDto createChatDto);
    }
}

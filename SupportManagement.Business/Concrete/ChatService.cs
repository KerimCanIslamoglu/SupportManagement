using SupportManagement.Business.Abstract;
using SupportManagement.DataAccess.Abstract;
using SupportManagement.Entities;
using SupportManagement.Model.Model;
using SupportManagement.Model.Model.Dto.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Business.Concrete
{
    public class ChatService : IChatService
    {
        private IChatDal _chatDal;

        public ChatService(IChatDal chatDal)
        {
            _chatDal = chatDal;
        }

        public ResponseModel<CreateChatDto> CreateChat(CreateChatDto createChatDto)
        {
            var response = new ResponseModel<CreateChatDto>();

            _chatDal.Create(new Chat
            {
                Content = createChatDto.Content,
                SentOn = DateTime.Now
            });

            response.Success = true;
            response.StatusCode = 200;
            response.Message = "Success";
            response.Response = null;

            return response;
        }
    }
}

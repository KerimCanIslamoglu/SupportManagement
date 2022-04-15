using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportManagement.Business.Abstract;
using SupportManagement.Model.Model.Dto.Chat;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportManagement.Api.Controllers
{
    [ApiController]
    public class ChatController : ControllerBase
    {
        public IChatService _chatService { get; set; }

        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        [HttpPost]
        [Route("api/[controller]/CreateChat")]
        public IActionResult CreateChat(CreateChatDto createChatDto)
        {
            var result = _chatService.CreateChat(createChatDto);

            return Ok(result);
        }
    }
}

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
        private ITeamService _teamService;
        public IChatService _chatService { get; set; }

        public ChatController(ITeamService teamService, IChatService chatService)
        {
            _teamService = teamService;
            _chatService = chatService;
        }

        [HttpGet]
        [Route("api/[controller]/GetTeams")]
        public IActionResult GetTeams()
        {
            var result = _teamService.GetTeamsWithAllTheirMembers();

            return Ok(result);
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

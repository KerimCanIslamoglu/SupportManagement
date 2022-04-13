using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportManagement.Business.Abstract;
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

        public ChatController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        [Route("api/[controller]/GetTeams")]
        public IActionResult GetTeams()
        {
            var teams = _teamService.GetTeamsWithAllTheirMembers();

            return Ok(teams);
        }

        [HttpPost]
        [Route("api/[controller]/SupportRequest")]
        public IActionResult SupportRequest()
        {
            return Ok("hi");
        }
    }
}

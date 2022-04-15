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
    public class TeamController : ControllerBase
    {
        private ITeamService _teamService;

        public TeamController(ITeamService teamService)
        {
            _teamService = teamService;
        }

        [HttpGet]
        [Route("api/[controller]/GetTeams")]
        public IActionResult GetTeams()
        {
            var result = _teamService.GetTeams();

            return Ok(result);
        }
    }
}

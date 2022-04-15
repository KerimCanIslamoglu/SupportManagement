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
    public class TeamMemberController : ControllerBase
    {
        private ITeamMemberService _teamMemberService;

        public TeamMemberController(ITeamMemberService teamMemberService)
        {
            _teamMemberService = teamMemberService;
        }

        [HttpGet]
        [Route("api/[controller]/GetTeamMembers")]
        public IActionResult GetTeamMembers()
        {
            var result = _teamMemberService.GetTeamMembers();

            return Ok(result);
        }
    }
}

using SupportManagement.Business.Abstract;
using SupportManagement.DataAccess.Abstract;
using SupportManagement.Model.Model;
using SupportManagement.Model.Model.Dto.TeamMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Business.Concrete
{
    public class TeamMemberService : ITeamMemberService
    {
        private ITeamMemberDal _teamMemberDal;

        public TeamMemberService(ITeamMemberDal teamMemberDal)
        {
            _teamMemberDal = teamMemberDal;
        }

        public ResponseModel<List<TeamMemberDto>> GetTeamMembers()
        {
            var response = new ResponseModel<List<TeamMemberDto>>();

            var teamMembers = _teamMemberDal.GetAll().Select(x => new TeamMemberDto
            {
                Id = x.Id,
                TeamId = x.TeamId,
                SeniorityId = x.SeniorityId,
                QueueName = x.QueueName,
            }).ToList();

            response.Success = true;
            response.StatusCode = 200;
            response.Message = "Success";
            response.Response = teamMembers;

            return response;
        }
    }
}

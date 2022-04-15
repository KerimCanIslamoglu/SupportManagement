using SupportManagement.Business.Abstract;
using SupportManagement.DataAccess.Abstract;
using SupportManagement.Model.Model;
using SupportManagement.Model.Model.Dto.Seniority;
using SupportManagement.Model.Model.Dto.Team;
using SupportManagement.Model.Model.Dto.TeamMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Business.Concrete
{
    public class TeamService : ITeamService
    {
        private ITeamDal _teamDal;

        public TeamService(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }

        public ResponseModel<List<TeamDto>> GetTeams()
        {
            var response = new ResponseModel<List<TeamDto>>();

            var teams = _teamDal
               .GetAll(x=>x.IsOverflowTeam==false)
               .Select(td => new TeamDto
               {
                   Id = td.Id,
                   TeamName = td.TeamName,
                   ShiftStarts = td.ShiftStarts,
                   ShiftEnds = td.ShiftEnds,
                   IsOverflowTeam = td.IsOverflowTeam,
               }).ToList();

            response.Success = true;
            response.StatusCode = 200;
            response.Message = "Success";
            response.Response = teams;

            return response;
        }

        public ResponseModel<List<TeamDto>> GetAvailableTeamWithAllTheirMembers()
        {
            var response = new ResponseModel<List<TeamDto>>();

            var teams = _teamDal
                .GetTeamWithMembersAndSeniorities()
                .Select(td => new TeamDto
                {
                    Id = td.Id,
                    TeamName = td.TeamName,
                    ShiftStarts = td.ShiftStarts,
                    ShiftEnds = td.ShiftEnds,
                    IsOverflowTeam = td.IsOverflowTeam,
                    TeamMembers = td.TeamMembers.Select(tmd => new TeamMemberDto
                    {
                        Id = tmd.Id,
                        TeamId = tmd.TeamId,
                        SeniorityId = tmd.SeniorityId,
                        QueueName=tmd.QueueName,
                        Seniority = new SeniorityDto
                        {
                            Id = tmd.Seniority.Id,
                            SeniorityName = tmd.Seniority.SeniorityName,
                            Multiplier = tmd.Seniority.Multiplier,
                            AssignmentOrder = tmd.Seniority.AssignmentOrder
                        }
                    }).ToList()
                }).ToList();

            response.Success = true;
            response.StatusCode = 200;
            response.Message = "Success";
            response.Response = teams;

            return response;
        }
    }
}

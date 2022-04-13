using SupportManagement.Model.Model;
using SupportManagement.Model.Model.Dto.Team;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Business.Abstract
{
    public interface ITeamService
    {
        ResponseModel<List<TeamDto>> GetTeamsWithAllTheirMembers();
    }
}

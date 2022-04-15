using SupportManagement.Model.Model;
using SupportManagement.Model.Model.Dto.TeamMember;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Business.Abstract
{
    public interface ITeamMemberService
    {
        ResponseModel<List<TeamMemberDto>> GetTeamMembers();
    }
}

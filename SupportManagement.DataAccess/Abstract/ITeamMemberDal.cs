using SupportManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.DataAccess.Abstract
{
    public interface ITeamMemberDal : IRepositoryBase<TeamMember>
    {
        List<TeamMember> GetTeamMemberWithSupportQueue(int teamId);
        List<TeamMember> GetTeamMembersByTeamId(int teamId);
    }
}

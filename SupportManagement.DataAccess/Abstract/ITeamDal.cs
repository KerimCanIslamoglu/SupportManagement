using SupportManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.DataAccess.Abstract
{
    public interface ITeamDal:IRepositoryBase<Team>
    {
        List<Team> GetTeamWithMembersAndSeniorities();
    }
}

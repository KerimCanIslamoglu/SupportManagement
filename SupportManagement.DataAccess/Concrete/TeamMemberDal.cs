using Microsoft.EntityFrameworkCore;
using SupportManagement.DataAccess.Abstract;
using SupportManagement.DataAccess.Context;
using SupportManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.DataAccess.Concrete
{
    public class TeamMemberDal : GenericRepository<TeamMember, ApplicationDbContext>, ITeamMemberDal
    {
        private ApplicationDbContext _db;

        public TeamMemberDal(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<TeamMember> GetTeamMembersByTeamId(int teamId)
        {
            return _db.TeamMembers
                .Include(x => x.Seniority)
                .Include(x => x.Team)
                .Where(x => x.TeamId == teamId)
                .ToList();
        }

        public List<TeamMember> GetTeamMemberWithSupportQueue(int teamId)
        {
            return _db.TeamMembers
                 .Include(x => x.Seniority)
                 .Include(x => x.SupportQueues.Where(x => x.AssignedOn.Value.Day == DateTime.Now.Day && x.IsAvailable == true).OrderBy(x => x.TeamMember.Seniority.AssignmentOrder))
                 .Where(x => x.TeamId == teamId)
                 .ToList();
        }
    }
}

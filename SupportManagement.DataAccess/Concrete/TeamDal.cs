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
    public class TeamDal : GenericRepository<Team, ApplicationDbContext>, ITeamDal
    {
        private ApplicationDbContext _db;

        public TeamDal(ApplicationDbContext db)
        {
            _db = db;
        }

        public List<Team> GetTeamWithMembersAndSeniorities()
        {
            return _db.Teams
                .Include(x => x.TeamMembers)
                .ThenInclude(y=>y.Seniority)
                .ToList();
        }
    }
}

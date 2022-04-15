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
    }
}

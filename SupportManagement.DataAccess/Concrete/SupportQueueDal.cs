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
    public class SupportQueueDal : GenericRepository<SupportQueue, ApplicationDbContext>, ISupportQueueDal
    {
        private ApplicationDbContext _db;

        public SupportQueueDal(ApplicationDbContext db)
        {
            _db = db;
        }

        public SupportQueue GetNextAvailableSupportQueueByTeamId(int teamId)
        {
            return _db.SupportQueues
                .Include(x=>x.TeamMember)
                .ThenInclude(x=>x.Seniority)
                .Where(x => x.IsAvailable == true 
                         && x.AssignedOn == null
                         && x.TeamMember.TeamId == teamId)
                .OrderBy(x => x.TeamMember.Seniority.AssignmentOrder)
                .FirstOrDefault();
        }

        public List<SupportQueue> GetSupportQueueByTeamId(int teamId)
        {
            return _db.SupportQueues
                      .Include(x => x.TeamMember)
                      .Where(x => x.TeamMember.TeamId == teamId 
                               && x.AssignedOn.Value.Day == DateTime.Now.Day)
                      .ToList();

        }
    }
}

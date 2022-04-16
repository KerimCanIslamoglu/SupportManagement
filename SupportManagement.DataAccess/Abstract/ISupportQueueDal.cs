using SupportManagement.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.DataAccess.Abstract
{
    public interface ISupportQueueDal : IRepositoryBase<SupportQueue>
    {
        List<SupportQueue> GetSupportQueueByTeamId(int teamId);
        SupportQueue GetNextAvailableSupportQueueByTeamId(int teamId);
    }
}

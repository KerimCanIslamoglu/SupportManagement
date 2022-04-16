using SupportManagement.Model.Model;
using SupportManagement.Model.Model.Dto.SupportQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Business.Abstract
{
    public interface ISupportQueueService
    {
        ResponseModel<List<SupportQueueDto>> GetSupportQueues();
    }
}

using SupportManagement.Business.Abstract;
using SupportManagement.DataAccess.Abstract;
using SupportManagement.Model.Model;
using SupportManagement.Model.Model.Dto.SupportQueue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportManagement.Business.Concrete
{
    public class SupportQueueService : ISupportQueueService
    {
        private ISupportQueueDal _supportQueueDal;

        public SupportQueueService(ISupportQueueDal supportQueueDal)
        {
            _supportQueueDal = supportQueueDal;
        }
        public ResponseModel<List<SupportQueueDto>> GetSupportQueues()
        {
            var response = new ResponseModel<List<SupportQueueDto>>();

            var supportQueues = _supportQueueDal.GetAll().Select(x => new SupportQueueDto
            {
                Id = x.Id,
                TeamMemberId = x.TeamMemberId,
                IsAvailable = x.IsAvailable,
                CreatedOn = x.CreatedOn,
                AssignedOn = x.AssignedOn
            }).ToList();

            response.Success = true;
            response.StatusCode = 200;
            response.Message = "Success";
            response.Response = supportQueues;

            return response;
        }
    }
}

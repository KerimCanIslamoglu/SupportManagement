using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SupportManagement.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SupportManagement.Api.Controllers
{
    [ApiController]
    public class SupportQueueController : ControllerBase
    {
        private ISupportQueueService _supportQueueService;

        public SupportQueueController(ISupportQueueService supportQueueService)
        {
            _supportQueueService = supportQueueService;
        }

        [HttpGet]
        [Route("api/[controller]/GetSupportQueues")]
        public IActionResult GetSupportQueues()
        {
            var result = _supportQueueService.GetSupportQueues();

            return Ok(result);
        }
    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using reporting.Models;
using System;
using System.Linq;

namespace reporting.Controllers
{
    [Route("api/[controller]")]
    public class LogActivityController : ControllerBase
    {
        private readonly Data.ILogActivityRepository c_logActivityRepository;



        public LogActivityController(
            [FromServices] Data.ILogActivityRepository logActivityRepository)
        {
            this.c_logActivityRepository = logActivityRepository;
        }


        [HttpPost]
        public IActionResult Post(
            [FromBody] Models.LogActivityRequest logActivityRequest)
        {
            Console.WriteLine($"111111111111111111111");
            var _requestId = Request.Headers["X-Request-Id"].ToString();
            Console.WriteLine($"22222222222222222222222222");
            var _correlationId = Request.Headers["X-Correlation-Id"].ToString();

            Console.WriteLine($"3333333333333333333333333");

            Console.WriteLine("SDFSDFDFSDF");
            var _logActivity = new Entity.LogActivity(
                Guid.Parse(_correlationId),
                Guid.Parse(_requestId),
                logActivityRequest.Service,
                logActivityRequest.Activity,
                logActivityRequest.ActivityDetail);

            Console.WriteLine($"4444444444444444444444444");
            this.c_logActivityRepository.Log(_logActivity);
            Console.WriteLine("SDFSDFDFSDF");

            return this.StatusCode(StatusCodes.Status201Created);
        }


        [HttpGet]
        public IActionResult Get()
        {
            var _logActivityData = this.c_logActivityRepository.GetRecentLogs();
            var _logActivityModel = _logActivityData
                .Select(
                    item => new LogActivity()
                    {
                        Id = item.Id,
                        CorrelationId = item.CorrelationId,
                        RequestId = item.RequestId,
                        Service = item.Service,
                        Activity = item.Activity,
                        ActivityDetail = item.ActivityDetail,
                        Timestamp = item.Timestamp
                    }.ToString());

            return this.StatusCode(StatusCodes.Status201Created, _logActivityModel);
        }
    }
}

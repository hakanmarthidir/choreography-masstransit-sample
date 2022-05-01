using Choreography.CreditService.Contracts;
using Choreography.SharedKernel.Credit;
using Choreography.SharedKernel.Interfaces;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Choreography.CreditService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CreditController : ControllerBase
    {

        private readonly IPublishEndpoint _publishEndpoint;

        public CreditController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("CreditService...");
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreditDto model)
        {
            //firstly i need to persist my CreditDto within database. 
            //...your codes here....
            //if data persistence is successfull then send your event to the publishers

            CreditDemandCreated demandCreated = new CreditDemandCreated()
            {
                UserId = model.UserId,
                Amount = model.CreditAmount
            };

            await this._publishEndpoint.Publish(demandCreated).ConfigureAwait(false);
            return Ok("Succesfully requested...");
        }
    }
}
using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using dapr.microservice.webapi.Models;
using Dapr.Client;

namespace dapr.microservice.webapi.Controllers
{
    [ApiController]
    public class PubSubController : ControllerBase
    {
        private readonly ILogger _logger;

        public PubSubController(ILogger<PubSubController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("/api/order")]
        public async Task<IActionResult> ReceiveOrder([FromBody] Order order)
        {
            var daprClient = new DaprClientBuilder().Build();
            _logger.LogInformation($"Order with ID {order.Id} received!");
            //validate BS 
            await daprClient.PublishEventAsync<Order>("pubsub", "ordertopic", order);
            _logger.LogInformation($"Order with ID {order.Id} published");
            return Ok();
        }

        [Topic("pubsub", "ordertopic")]
        [HttpPost]
        [Route("ordertopic")]
        public async Task<IActionResult> ProcessOrder([FromBody] Order order)
        {
            await Task.Delay(0);

            //Process order placeholder

            _logger.LogInformation($"Order with id {order.Id} processed!");
            return Ok();
        }
    }
}
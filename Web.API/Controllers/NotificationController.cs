using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Web.API.Model;

namespace Web.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationController(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost]
        public IActionResult SendNotification([FromBody] string message)
        {
            _hubContext.Clients.All.SendAsync("ReceiveNotification", message);
            return Ok();
        }
    }
}

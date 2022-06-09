using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using SignalRApplication.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDesktop.Controllers
{
    [ApiController]
    [Route("message")]
    public class MessageController : ControllerBase
    {
        private readonly IHubContext<MessageHub, IHubClient> _hubContext;

        public MessageController(IHubContext<MessageHub, IHubClient> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet, Route("send")]
        public async Task<IActionResult> Get()
        {
            await _hubContext.Clients.All.BroadcastMessage("Hello");
            return Ok();
        }
    }
}

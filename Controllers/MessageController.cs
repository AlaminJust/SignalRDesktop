using Microsoft.AspNetCore.Mvc;
using SignalRApplication.Services;
using SignalRDesktop.Services;
using System.Threading.Tasks;

namespace SignalRDesktop.Controllers
{
    [ApiController]
    [Route("messages")]
    public class MessageController : ControllerBase
    {
        private readonly SignalRService _signalRService;

        public MessageController(SignalRService signalRService)
        {
            _signalRService = signalRService;
        }

        [HttpPost, Route("send")]
        public async Task<IActionResult> Get(Message message)
        {
            await _signalRService.SendAllAsync(message);
            return Ok();
        }
    }
}

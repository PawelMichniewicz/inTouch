using CommunicationWebApi.Models;
using CommunicationWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly MessageService queryService;
        private readonly ILogger<MessageController> logger;

        public MessageController(ILogger<MessageController> logger, MessageService service)
        {
            this.logger = logger;
            queryService = service;
        }

        // api/Message?id=3
        [HttpGet]
        public async Task<ActionResult<Message>> GetMessageAsync(int id)
        {
            logger.LogTrace($"{nameof(this.GetMessageAsync)}: {nameof(id)} = {id}");
            Message? message = await queryService.GetMessageAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }

        // /api/Message/3
        [HttpGet("{id}")]
        public async Task<ActionResult<Message>> GetMessage2Async(int id)
        {
            logger.LogTrace($"{nameof(this.GetMessage2Async)}: {nameof(id)} = {id}");
            return await GetMessageAsync(id);
        }
    }
}

using CommunicationWebApi.Models;
using CommunicationWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomController : ControllerBase
    {
        private readonly ILogger<ChatRoomController> logger;
        private readonly ChatRoomService queryService;

        public ChatRoomController(ILogger<ChatRoomController> logger, ChatRoomService service)
        {
            this.logger = logger;
            queryService = service;
        }

        
    }
}

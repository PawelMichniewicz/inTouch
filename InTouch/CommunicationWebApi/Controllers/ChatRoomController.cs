using CommunicationWebApi.Models;
using CommunicationWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomController : CommonControllerBase<ChatRoomService>
    {
        public ChatRoomController(ILogger<ChatRoomController> logger, ChatRoomService service) : base (logger, service)
        { }
        
    }
}

using CommunicationWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CommonControllerBase
    {

        public UserController(ILogger<UserController> logger, UserService service) : base(logger, service)
        { }

        [HttpGet("{name}")]
        public async Task<ActionResult<ICollection<string?>>> GetUsersChatRoomsAsync(string name)
        {
            var chatRooms = await (queryService as UserService).QueryChatRoomsByUserAsync(name);
            if (chatRooms == null)
            {
                return NotFound();
            }
            return Ok(chatRooms);
        }
    }
}

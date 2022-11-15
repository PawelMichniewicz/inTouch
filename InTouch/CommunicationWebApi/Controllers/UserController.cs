using CommunicationWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : CommonControllerBase<IUserService>
    {

        public UserController(ILogger<UserController> logger, IUserService service) : base(logger, service)
        { }

        [HttpGet("{name}")]
        public async Task<ActionResult<ICollection<string>?>> GetUsersChatRoomsAsync(string name)
        {
            logger.LogTrace($"{nameof(UserController.GetUsersChatRoomsAsync)} : {nameof(name)} = {name}");
            var chatRooms = await service.QueryChatRoomsByUserAsync(name);
            if (chatRooms == null)
            {
                return NotFound();
            }
            return Ok(chatRooms);
        }

        //[HttpPost]
    }
}

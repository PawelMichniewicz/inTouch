using CommunicationWebApi.Models;
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
        public async Task<ActionResult<ICollection<string>?>> GetUserChatRoomsAsync(string name)
        {
            logger.LogTrace($"{nameof(UserController.GetUserChatRoomsAsync)} : {nameof(name)} = {name}");
            var chatRooms = await service.QueryChatRoomsByUserAsync(name);
            if (chatRooms == null)
            {
                return NotFound();
            }
            return Ok(chatRooms);
        }

        [HttpGet("userName")]
        public async Task<ActionResult<User?>> GetUserProfileAsync(string userName)
        {
            logger.LogTrace($"{nameof(UserController.GetUserProfileAsync)} : {nameof(userName)} = {userName}");
            var profile = await service.QueryUserProfileAsync(userName);
            if (profile == null)
            {
                return NotFound();
            }
            return Ok(profile);
        }

        //[HttpPost]
    }
}

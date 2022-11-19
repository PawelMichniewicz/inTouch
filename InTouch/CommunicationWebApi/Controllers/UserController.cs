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

        // TODO: this should rather be in ChatRoomController
        // TODO: BUG should operate on ID rather than name
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

        // GET: api/User/userName?userName=Ross%20Geller
        // TODO: BUG should operate on ID rather than name
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

        
        // TODO: add UT for this
        // PUT: api/User/4
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserAsync(int id, User profile)
        {
            if (id != profile.Id)
            {
                return BadRequest();
            }

            if (await service.UpdateProfileAsync(profile))
            {
                return NoContent();
            }
            else
            {
                return NotFound();
            }

        }

    }
}

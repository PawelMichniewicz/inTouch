using CommunicationWebApi.Models;
using CommunicationWebApi.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatRoomController : CommonControllerBase<IChatRoomService>
    {
        public ChatRoomController(ILogger<ChatRoomController> logger, IChatRoomService service) : base(logger, service)
        { }

        [HttpGet("{id}")]
        public async Task<ActionResult<ChatRoom>?> GetChatRoomAsync(int id)
        {
            var chatRoom = await service.QueryChatRoomAsync(id);
            if (chatRoom is null)
            {
                return NotFound();
            }
            return Ok(chatRoom);
        }

        // TODO: BUG should operate on ID rather than name
        [HttpGet("{name}")]
        public async Task<ActionResult<ICollection<string>?>> GetUserChatRoomsAsync(string name)
        {
            logger.LogTrace($"{nameof(this.GetUserChatRoomsAsync)} : {nameof(name)} = {name}");
            var chatRooms = await service.QueryChatRoomsByUserAsync(name);
            if (chatRooms == null)
            {
                return NotFound();
            }
            return Ok(chatRooms);
        }

        [HttpPost]
        public async Task<ActionResult<ChatRoom>> CreateChatRoomAsync(ChatRoom chatRoom)
        {
            _ = await service.AddChatRoomAsync(chatRoom);
            return CreatedAtAction(nameof(CreateChatRoomAsync), new { id = chatRoom.Id }, chatRoom);
        }
    }
}

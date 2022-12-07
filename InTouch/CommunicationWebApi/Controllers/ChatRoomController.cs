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

        [HttpPost]
        public async Task<ActionResult<ChatRoom>> CreateChatRoomAsync(ChatRoom chatRoom)
        {
            _ = await service.AddChatRoomAsync(chatRoom);
            return CreatedAtAction(nameof(CreateChatRoomAsync), new { id = chatRoom.Id }, chatRoom);
        }
    }
}

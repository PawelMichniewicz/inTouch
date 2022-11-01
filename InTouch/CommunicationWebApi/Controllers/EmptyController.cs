using CommunicationWebApi.Models;
using CommunicationWebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace CommunicationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmptyController : ControllerBase
    {
        private readonly MessageService service;

        public EmptyController(MessageService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ActionResult<Message>> GetMessageAsync(int id)
        {
            Message? message = await service.GetMessageAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }
    }
}

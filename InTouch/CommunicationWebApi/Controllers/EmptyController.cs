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
        private readonly MessageService queryService;

        public EmptyController(MessageService service)
        {
            queryService = service;
        }

        [HttpGet]
        public async Task<ActionResult<Message>> GetMessageAsync(int id)
        {
            Message? message = await queryService.GetMessageAsync(id);

            if (message == null)
            {
                return NotFound();
            }

            return message;
        }
    }
}

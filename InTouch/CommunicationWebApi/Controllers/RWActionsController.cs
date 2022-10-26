using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommunicationWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RWActionsController : ControllerBase
    {
        private static string[] secrets = { "secret1", "secret2", "secret3", "secret4", };

        // GET: api/<RWActionsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return secrets;
        }

        // GET api/<RWActionsController>/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id >= secrets.Length)
            {
                return "not enough secrets";
            }
            return $"secret #{id} is {secrets[id]}";
        }

        // POST api/<RWActionsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
            if (value is not null)
            {
                secrets = secrets.Append(value).ToArray();
            }
        }

        // PUT api/<RWActionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
            if (id <= secrets.Length)
            {
                secrets[id] = value;
            }
        }

        // DELETE api/<RWActionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id <= secrets.Length)
            {
                var toDelete = secrets[id];
                secrets = secrets.Where(secret => secret != toDelete).ToArray();
            }
        }
    }
}

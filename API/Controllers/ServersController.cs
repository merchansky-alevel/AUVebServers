using Lib.Models;
using Lib.Services;
using System.Web.Http;

namespace AUapi.Controllers
{
    [RoutePrefix("api/servers")]
    public class ServersController : ApiController
    {
        private IServerService _serverService = new ServerService();

        // GET: api/Servers
        [HttpGet]
        public IHttpActionResult Get()
        {
            var servers = _serverService.GetAll();

            return Ok(servers);
        }

        // GET: api/Servers/5
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var server = _serverService.Get(id);

            if (server == null)
            {
                return NotFound();
            }

            return Ok(server);
        }

        // POST: api/Servers
        [HttpPost]
        public IHttpActionResult Post([FromBody]Server value)
        {
            _serverService.Add(value);

            return Ok();
        }

        // PUT: api/Servers/5
        [HttpPut]
        public IHttpActionResult Put([FromBody]Server value)
        {
            _serverService.Update(value);

            return Ok();
        }

        // DELETE: api/Servers/5
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            _serverService.Delete(id);

            return Ok();
        }
    }
}

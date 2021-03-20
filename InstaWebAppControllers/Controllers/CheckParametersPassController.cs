using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InstaWebAppControllers.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CheckParametersPassController : ControllerBase
    {
        private string[] StringsForBodyRequest = { "1 string", "2 string" };
        private string[] StringsForUriRequest = { "3 string" };

        // GET: /Stories/1?indexFromUri=1
        [HttpGet("{index}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<string>> GetUrlStories(int index, int indexFromUri, [FromBody] Parameters p)
        {
            return Ok(new string[]{ StringsForBodyRequest[index], StringsForBodyRequest[indexFromUri], StringsForUriRequest[p.IndexFromBody]});
        }

        public class Parameters
        {
            public int IndexFromBody { get; set; }
        }
    }
}

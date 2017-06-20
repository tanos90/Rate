using System.Web.Http;
using Rate.Services.Abstract;
using Rate.Models;

namespace Rate.Controllers
{ 
    [Route("api/[controller]")]
    public class FlickController : ApiController
    {
        private readonly IFlickService _flickService;

        public FlickController()
        {

        }
        public FlickController(IFlickService flickService)
        {
            _flickService = flickService;

        }

        // POST api/values
        [Route("api/flick")]
        [HttpGet]
        public IHttpActionResult Get(string title)
            {
            if (!string.IsNullOrWhiteSpace(title))
            {
                FlickDTO flick = _flickService.FetchByTitle(title);
                if (flick != null)
                {
                    return Ok(flick);
                }
                else
                {
                    return NotFound();
                }
            }
            return BadRequest();
            
        }

    }
}


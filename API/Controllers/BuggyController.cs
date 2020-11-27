using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class BuggyController : BaseApiController
    {
        private readonly StoreContext _storeContext;

        public BuggyController(StoreContext storeContext)
        {
            _storeContext = storeContext;
        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            var thing = _storeContext.Products.Find(42);
            if (thing == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var thing = _storeContext.Products.Find(42);
            
            var thingToReturn = thing.ToString();

            return Ok(); 
        }

        [HttpGet("badrequest/{id}")]
        public ActionResult GetNotFound(int id)
        {
            return BadRequest();
        }

        [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
            return Ok();
        }

    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using learn_api.Models;
using learn_api.Services;
namespace learn_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class userController : ControllerBase
    {
        //json editor to read your file and simply it 
        [HttpGet]
        public ActionResult<List<user>> GETALL()
        {
            return userservices.getall();
        }
        [HttpGet("{id}")] // becouse we get buse in id
        public ActionResult<user> GET(int id)
        {
            var temp_user = userservices.getone(id);
            if (temp_user == null)
                return NotFound();
            return temp_user;
        }
        [HttpPost]
        public ActionResult create(user user)
        {
            userservices.setone(user);
            return CreatedAtAction(nameof(create),new {id=user.id},user); //it return status code 201  Note ->this fun take 3 paramters
        }

        [HttpPut("{id}")]
        public ActionResult edit(int id,user user)
        {
            if(id!=user.id)
                return BadRequest();
            var temp_user = userservices.getone(id);
            if (temp_user == null)
                return NotFound();
            userservices.update(user);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult delete(int id)
        {
            var temp_user = userservices.getone(id);
            if (temp_user.id != id)
            {
                return NotFound();
            }
            userservices.delete(id);
            return NoContent();
        }
    }
}

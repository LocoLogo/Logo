using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
 
using TestMongoDB.Models;
using MongoDB.Bson;
 
namespace TestMongoDB.Controllers
{
    [Route("api/User")]
    public class UserAPIController : Controller
    {
        DataAccess objds;
 
        public UserAPIController()
        {
            objds = new DataAccess(); 
        }
 
        [HttpGet]
        public IEnumerable<WUser> Get()
        {
            return objds.GetUsers();
        }
        [HttpGet("{id:length(24)}")]
        public IActionResult Get(string id)
        {
            var user = objds.GetUser(new ObjectId(id));
            if (user == null)
            {
                return NotFound();
            }
            return new ObjectResult(user);
        }
 
        [HttpPost]
        public IActionResult Post([FromBody]WUser p)
        {
            objds.Create(p);
            return new OkObjectResult(p);
        }
        [HttpPut("{id:length(24)}")]
        public IActionResult Put(string id, [FromBody]WUser p)
        {
            var recId = new ObjectId(id);
            var user = objds.GetUser(recId);
            if (user == null)
            {
                return NotFound();
            }
            
            objds.Update(recId, p);
            return new OkResult();
        }
 
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var user = objds.GetUser(new ObjectId(id));
            if (user == null)
            {
                return NotFound();
            }
 
            objds.Remove(user.Id);
            return new OkResult();
        }
    }
}
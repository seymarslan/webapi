using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        LoginDBContext context = new LoginDBContext();

        [HttpGet]
        public List<User> Get()
        {
            var users=context.Users.ToList();
            return users;
            
        }
        [HttpGet("{id}")]
        public User Get(int id)
        {
            var user=context.Users.Find(id);
            return user;
        }
        [HttpPost]
        public bool Post([FromBody]User userModel)
        {
            try
            {
                context.Users.Add(userModel);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
           
        }
        [HttpPut]
        public bool Put([FromBody]User userModel)
        {
            try
            {
                context.Users.Update(userModel);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            try
            {
                var user = context.Users.Find(id);
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
            
        }
    }
}

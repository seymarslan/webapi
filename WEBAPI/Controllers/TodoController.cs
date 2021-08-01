using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPI.Business;
using WEBAPI.Models;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        LoginDBContext context = new LoginDBContext();

        [HttpGet]
        public List<Todo> Get()
        {
            var todos = context.Todos.ToList();
            return todos;

        }
        [HttpGet("{id}")]
        public Todo Get(int id)
        {
            var todo = context.Todos.Find(id);
            return todo;
        }
        [HttpPost]
        public bool Post(Todo todoModel)
        {
            try
            {
                context.Todos.Add(todoModel);
                var result = context.SaveChanges();
                if (result > 0)
                {
                    EmailService emailService = new EmailService();
                    var user=context.Users.Find(todoModel.UserID);
                    emailService.Send(todoModel.User.Email,"ToDo Eklendi.","<b>Todo içeriği:</b></br>"+todoModel.Info);
                }
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        [HttpPut]
        public bool Put([FromBody] Todo todoModel)
        {
            try
            {
                context.Todos.Update(todoModel);
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
                var todo = context.Todos.Find(id);
                context.Todos.Remove(todo);
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
